#pragma once
#include <vector>
#include <functional>

class Conway // TODO: Singleton?
{
   public:
      Conway(const int length, const int turn);
      ~Conway();

      // 요약
      //    좌표 기준으로 8방향을 탐색합니다.
      //
      // 반환
      //    8방향에 존재하는 유닛 수
      int GetNearUnitCount(const int x, const int y);

      // 요약
      //    x, y 좌표가 보드 사이즈를 넘어갈 경우,
      //    나머지 연산, 음수를 맨 마지막 인덱스로 변환합니다.
      //
      // 반환
      //    변환된 좌표의 상태
      bool GetClampedBoardInfo(int x, int y);

      // 요약
      //    노드가 존재하지 않는지 확인합니다.
      //
      // 반환
      //    노드가 존재하지 않으면 true
      bool CheckIsAllDead();

      // 요약
      //    제한된 턴 수와 현재 턴을 비교합니다.
      //
      // 반환
      //    제한된 턴 밖이면 true
      bool TurnLimit();

      // 요약
      //    좌표에 유닛을 추가합니다.
      void AddUnit(const int x, const int y);

      // 요약
      //    한 턴을 진행합니다.
      //    노드의 삶과 죽음을 처리합니다.
      void Turn();

      // 요약
      //    _board 를 출력합니다.
      void Print(char node, char empty);

   private:
      bool **_board; // 생명게임 보드
      int _length;   // 보드 변 길이
      int _turn;     // 최대 턴
      int _curTurn;  // 현재 턴

      // 요약
      //    각 원소마다 함수를 호출합니다.
      void ForEach(std::function<void(bool* node, int x, int y)> callback,
                   std::function<void()> eol = NULL);

      // 요약
      //    생명게임 보드를 깊은 복사합니다.
      // 반환
      //    깊은 복사된 보드
      bool** Copy();

      // 요약
      //    원본 보드에 깊은 복사합니다.
      void Override(bool** copied);

      // 요약
      //    복사한 보드를 삭제합니다.
      void DeleteCopied(bool **copied);
};