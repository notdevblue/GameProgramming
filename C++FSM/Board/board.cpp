#include "./board.h"
#include <cmath>

Board::Board(int x, int y, int enemyX, int enemyY)
{
   int sx;
   int sy;

   _stopThread = false;
   _redraw = true;

   _player = new COORD(x / 2, y / 2);
   _playerData = new CHARACTER(10, 1, 3.0, _player);

   _enemy = new COORD(enemyX, enemyY);
   _enemyData = new ENEMY(5, 1, 1.0, _enemy);

   getmaxyx(w, sx, sy);
   COORD *_screen = new COORD(sx, sy);

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

   delete _playerData;
   delete _enemyData;

   delete _screen;

   endwin();
}

void Board::WaitAllThreads()
{
   _enemyData->WaitAllThreads();

   pthread_join(_inputThread, NULL);
   pthread_join(_printThread, NULL);
}

void Board::AttackPlayer()
{
   // double distance = DistanceWithPlayer();
   // if(_enemyData->_atkDistance >= distance)
   {
      _playerData->Damage(_enemyData->_atk);
   }
}

void Board::AttackEnemy()
{
   // double distance = DistanceWithPlayer();
   // if (_playerData->_atkDistance >= distance)
   {
      _enemyData->Damage(_playerData->_atk);
   }
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
      refresh();
   }

   return status;
}

bool Board::Redraw()
{
   bool status;

   pthread_mutex_lock(&_mutex);
   status = _redraw;
   _redraw = false;
   pthread_mutex_unlock(&_mutex);

   return status;
}

void Board::SetRedraw()
{
   pthread_mutex_lock(&_mutex);
   _redraw = true;
   pthread_mutex_unlock(&_mutex);
}