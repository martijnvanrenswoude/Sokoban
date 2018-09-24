using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Game
    {
        InputView InputView = new InputView();
        OutputView outputView = new OutputView();
        Parser parser = new Parser();
        PlayField playField = new PlayField();
    }
}