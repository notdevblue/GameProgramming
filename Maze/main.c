#include <stdio.h>
#include <stdlib.h>

int g_maze[8][8] =
{
   {0, 0, 0, 0, 0, 0, 0, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 1, 1, 1, 1, 0},
   {1, 1, 0, 0, 1, 1, 1, 0},
   {1, 1, 1, 0, 0, 0, 0, 0},
   {1, 1, 1, 0, 1, 1, 1, 1},
   {1, 0, 0, 0, 0, 0, 0, 3}
};

int g_visited[8][8];

int g_dx[4];
int g_dy[4];
int g_x = 0;
int g_y = 0;

void search();
void print();

void main()
{
   printf("[D]FS, [B]FS\r\n");
   char input = getchar();
   if (input == 'D' || input == 'd')
   {
      g_dx[0] = g_dx[1] = g_dy[2] = g_dy[3] = 0;
      g_dx[2] = g_dy[0] = 1;
      g_dx[3] = g_dy[1] = -1;
   }
   else if (input == 'B' || input == 'b')
   {
      g_dx[2] = g_dx[3] = g_dy[0] = g_dy[1] = 0;
      g_dx[0] = g_dy[2] = 1;
      g_dx[1] = g_dy[3] = -1;
   }
   else
   {
      printf("Wrong input");
      return;
   }

   search();

   return;
}

void search()
{
   int x = g_x;
   int y = g_y;

   while (1)
   {
      for (int i = 0; i < 4; ++i)
      {
         x = g_x + g_dx[i];
         y = g_y + g_dy[i];

         if ((g_visited[y][x]) || (x > 7 || x < 0 || y > 7 || y < 0))
            continue;  

         if (g_maze[y][x] == 3)
         {
            g_x = x;
            g_y = y;
            print();
            return;
         }

         if (!g_maze[y][x])
         {
            g_visited[y][x] = 1;
            g_x = x;
            g_y = y;
            break;
         }
      }

      print();

      system("sleep 0.1; clear");
   }
}


void print()
{
   for (int y = 0; y < 8; ++y)
   {
      for (int x = 0; x < 8; ++x)
      {
         if (g_x == x && g_y == y)
            printf("x");
         else
            printf("%c", g_maze[y][x] ? (g_maze[y][x] == 3 ? '$' : '@') : ' ');
      }
      printf("\r\n");
   }
}