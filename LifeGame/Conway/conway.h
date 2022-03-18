class Conway
{
   public:
      Conway(int area);
      ~Conway();

      // 요약
      //    좌표 기준으로 8방향을 탐색합니다.
      //
      // 반환
      //    8방향에 존재하는 유닛 수
      int   GetNearUnitCount(const int& x, const int& y);

      // 요약
      //    x, y 좌표가 보드 사이즈를 넘어갈 경우,
      //    나머지 연산, 음수를 맨 마지막 인덱스로 변환합니다.
      //
      // 반환
      //    변환된 좌표의 상태
      bool  GetClampedBoardInfo(int x, int y);

      // 요약
      //    좌표에 유닛을 추가합니다.
      //
      // 반환
      //    이미 유닛이 존재하는 경우 false 을 반환합니다.
      bool AddUnit(const int& x, const int& y);

   private:
      bool **_board; // 생명게임 보드
      int _length;   // 보드 변 길이
};