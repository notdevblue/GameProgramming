#pragma once

typedef class coord
{
public:
   coord(int x, int y);

   int x;
   int y;
} COORD;


coord::coord(int x, int y) : x(x), y(y)
{

}
