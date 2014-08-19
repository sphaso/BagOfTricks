using System;

namespace GameOfLife
{
    /*
     *  TRIVIAL ITERATIVE SOLUTION OF CONWAY'S GAME OF LIFE
     */

    class Program
    {
        private static Int32[] _life = new[] { 0, 1, 0, 
                                               0, 1, 0, 
                                               0, 1, 0 };

        private static Int32 _side = 3;

        private static Int32 SumOfNeighbors(Int32 index)
        {
            var sum = 0;

            //left and right
            if (index - 1 >= 0 && index % _side != 0)
                sum += _life[index - 1];

            if (index + 1 < _life.Length && (index + 1) % _side != 0)
                sum += _life[index + 1];

            //up and down
            if (index - _side >= 0)
                sum += _life[index - _side];

            if (index + _side < _life.Length)
                sum += _life[index + _side];

            //diagonals
            if (index - (_side + 1) >= 0)
                sum += _life[index - (_side + 1)];

            if (index - (_side - 1) >= 0 && (index + 1) % _side != 0)
                sum += _life[index - (_side - 1)];

            if (index + (_side - 1) < _life.Length && index % _side != 0)
                sum += _life[index + (_side - 1)];

            if (index + (_side + 1) < _life.Length && (index + 1) % _side != 0)
                sum += _life[index + (_side + 1)];

            return sum;
        }

        private static void Print()
        {
            Console.WriteLine("----");
            Console.WriteLine(_life[0] + "\t" + _life[1] + "\t" + _life[2]);
            Console.WriteLine(_life[3] + "\t" + _life[4] + "\t" + _life[5]);
            Console.WriteLine(_life[6] + "\t" + _life[7] + "\t" + _life[8]);
            Console.WriteLine("----");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Int32[] newLife = new Int32[9];

                for (var i = 0; i < _life.Length; i++)
                {
                    var sum = SumOfNeighbors(i);

                    if (_life[i] == 0 && sum == 3)
                        newLife[i] = 1;
                    else if (_life[i] == 1 && (sum > 3 || sum < 2))
                        newLife[i] = 0;
                    else 
                        newLife[i] = _life[i];
                }

                _life = newLife;

                Print();
                Console.ReadLine();
            }
        }
    }
}
