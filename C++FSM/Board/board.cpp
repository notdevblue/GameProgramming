#include "./board.h"
#include <cmath>

Board::Board(int x, int y, int enemyX, int enemyY)
{
   int sx;
   int sy;

   _stopThread = false;

   _player = new COORD(x / 2, y / 2);
   _enemy = new COORD(enemyX, enemyY);

   getmaxyx(w, sx, sy);
   COORD *_screen = new COORD(sx, sy);

   _unitmap.insert(std::make_pair("PLAYER", _player));
   _unitmap.insert(std::make_pair("ENEMY", _enemy));

   w = initscr();
   clear();
   noecho();
   keypad(w, true);
   curs_set(0);

   pthread_mutex_init(&_mutex, NULL);
   pthread_create(&_inputThread, NULL,
                  &Board::InputThreadHelper, this);

   pthread_create(&_printThread, NULL,
                  &Board::PrintThreadHelper, this);
}

Board::~Board()
{
   delete _player;
   delete _enemy;
   delete _screen;

   endwin();
}

double Board::DistanceWithPlayer()
{
   pthread_mutex_lock(&_mutex);
   int x = _player->x - _enemy->x;
   int y = _player->y - _enemy->y;
   pthread_mutex_unlock(&_mutex);

   return std::sqrt(x * x + y * y);
}

void Board::WaitAllThreads()
{
   pthread_join(_inputThread, NULL);
   pthread_join(_printThread, NULL);
}

bool Board::CheckThreadRunStatus()
{
   bool status;

   // race condition
   pthread_mutex_lock(&_mutex);
   status = _stopThread;
   pthread_mutex_unlock(&_mutex);

   if(status)
   {
      clear();
      printw("Press any key to exit...");
      refresh();
   }

   return status;
}