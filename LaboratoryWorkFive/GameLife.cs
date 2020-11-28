using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWorkFive
{
    // Реализуйте последовательный алгоритм расчета состояний модели.
    public class GameLife {
        private int Heigth;
        private int Width;
        private bool[,] cells;

        public GameLife(int Heigth, int Width) {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = new bool[Heigth, Width];
            GenerateField();
        }

        public bool[,] Grow() {
            for (int i = 0; i < Heigth; i++) {
                for (int j = 0; j < Width; j++) {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j]) {
                        if (numOfAliveNeighbors < 2) {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3) {
                            cells[i, j] = false;
                        }
                    }
                    else {
                        if (numOfAliveNeighbors == 3) {
                            cells[i, j] = true;
                        }
                    }
                }
            }

            return cells;
        }

        public bool[,] GrowParallel()
        {
            Parallel.For(0, Heigth, (i) =>
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }
            );

            return cells;
        }

        private int GetNeighbors(int x, int y) {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++) {
                for (int j = y - 1; j < y + 2; j++) {
                    if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width))) {
                        if (cells[i, j] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        private void GenerateField() {
            Random generator = new Random();
            int number;
            for (int i = 0; i < Heigth; i++) {
                for (int j = 0; j < Width; j++) {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }
}
