using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe_Gruppe2;

namespace TicTacToeTest
{
    [TestClass]
    public sealed class TicTacToeTests
    {
        [TestMethod]
        public void Brett_Leer_Nach_Start()
        {
            var model = new Model(new SmallBoard());

            foreach (var row in model.Board)
            {
                foreach (var cell in row)
                {
                    Assert.AreEqual('\0', cell);
                }
            }
        }

        [TestMethod]
        public void Spieler_Wechselt()
        {
            var model = new Model(new SmallBoard());
            char startSpieler = model.CurrentPlayer;

            model.SetMove(0, 0);

            Assert.AreNotEqual(startSpieler, model.CurrentPlayer);
        }

        [TestMethod]
        public void Sieg_In_Zeile()
        {
            var model = new Model(new SmallBoard());

            model.SetMove(0, 0);
            model.SetMove(1, 0);
            model.SetMove(0, 1);
            model.SetMove(1, 1);
            model.SetMove(0, 2);

            Assert.AreEqual('X', model.GetWinner());
        }

        [TestMethod]
        public void Sieg_In_Spalte()
        {
            var model = new Model(new SmallBoard());

            model.SetMove(0, 0);
            model.SetMove(0, 1);
            model.SetMove(1, 0);
            model.SetMove(1, 1);
            model.SetMove(2, 0);

            Assert.AreEqual('X', model.GetWinner());
        }

        [TestMethod]
        public void Sieg_In_Diagonale()
        {
            var model = new Model(new SmallBoard());

            model.SetMove(0, 0);
            model.SetMove(1, 0);
            model.SetMove(1, 1);
            model.SetMove(2, 0);
            model.SetMove(2, 2);

            Assert.AreEqual('X', model.GetWinner());
        }

        [TestMethod]
        public void Unentschieden()
        {
            var model = new Model(new SmallBoard());

            model.SetMove(0, 0);
            model.SetMove(0, 1);
            model.SetMove(0, 2);
            model.SetMove(1, 1);
            model.SetMove(1, 0);
            model.SetMove(1, 2);
            model.SetMove(2, 1);
            model.SetMove(2, 0);
            model.SetMove(2, 2);

            Assert.AreEqual('\0', model.GetWinner());
        }

        [TestMethod]
        public void Ungültiger_Zug()
        {
            var model = new Model(new SmallBoard());

            model.SetMove(0, 0);
            bool zweiterZug = model.SetMove(0, 0);

            Assert.IsFalse(zweiterZug);
        }

        [TestMethod]
        public void Zug_Auf_Brett()
        {
            var model = new Model(new SmallBoard());
            var controller = new Controller(model, new View());

            controller.MakeMove(0, 0);

            Assert.AreEqual('X', model.Board[0][0]);
        }

        [TestMethod]
        public void Zug_Rückgängig()
        {
            var model = new Model(new SmallBoard());
            var controller = new Controller(model, new View());

            controller.MakeMove(0, 0);
            bool wurdeRückgängigGemacht = controller.UndoMove();

            Assert.IsTrue(wurdeRückgängigGemacht);
            Assert.AreEqual('\0', model.Board[0][0]);
        }

        [TestMethod]
        public void Brett_Grössen()
        {
            var small = new Model(new SmallBoard());
            var large = new Model(new LargeBoard());
            var huge = new Model(new HugeBoard());

            Assert.AreEqual(3, small.Board.Count);
            Assert.AreEqual(5, large.Board.Count);
            Assert.AreEqual(7, huge.Board.Count);
        }
    }
}