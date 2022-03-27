#include "./board.h"

void *Board::InputThreadHelper(void *context)
{
   return ((Board *)context)->InputThread();
}

void *Board::InputThread()
{
   int input;

   while(true)
   {
      if (CheckThreadRunStatus())
         break;

      input = getch(); // blocking
      ProcessInput(input);
   }

   return 0;
}

void Board::Move(COORD *unit, int x, int y)
{
   unit->x = x;
   unit->y = y;
}

void Board::ProcessInput(int input)
{
   switch(input)
   {
   #pragma region Movement
   case KEY_UP:
      if (_enemy->y == _player->y - 1 && 
          _enemy->x == _player->x)
          break;

      --_player->y;
      SetRedraw();
      break;

   case KEY_DOWN:
      if (_enemy->y == _player->y + 1 &&
          _enemy->x == _player->x)
         break;

      ++_player->y;
      SetRedraw();
      break;
      
   case KEY_LEFT:
      if (_enemy->x == _player->x - 1 &&
          _enemy->y == _player->y)
         break;

      --_player->x;
      SetRedraw();
      break;
      
   case KEY_RIGHT:
      if (_enemy->x == _player->x + 1 &&
          _enemy->y == _player->y)
         break;

      ++_playerData->_coord->x;
      SetRedraw();
      break;
   #pragma endregion // Movement

   case 'a': // 공격
      _playerData->Attack(_enemyData);
      SetRedraw();
      break;

   case 'q': // 종료
      pthread_mutex_lock(&_mutex);
      _stopThread = true;
      pthread_mutex_unlock(&_mutex);
      break;
   
   default:
      break;
   }
}