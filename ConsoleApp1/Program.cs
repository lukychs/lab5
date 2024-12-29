class MyMatrix
{
    private int n, m;
    private int[,] matrix;

    public MyMatrix(int n, int m, int a, int b)
    {
        this.n = n;
        this.m = m;
        matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Random rand = new Random();
                matrix[i, j] = rand.Next(a, b);
            }
        }
    }

    public MyMatrix Fill(int val1,  int val2)
    {
        MyMatrix matrix1 = new MyMatrix(n, m, 0, 0);

        for(int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Random rand = new Random();
                matrix[i, j] = rand.Next(val1, val2);
            }
        }

        return matrix1;
    }

    public MyMatrix ChangeSize(int n1, int m1)
    {
        MyMatrix matrix1 = new MyMatrix(n1, m1, 0, 0);

        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < m1; j++)
            {
                if (i >= n || j >= m)
                {
                    Random rand = new Random();
                    matrix1[i, j] = rand.Next(2, 5);
                }

                else
                {
                    matrix1[i, j] = matrix[i,j];
                }

            }
        }

        return matrix1;
        
    }

    public void ShowPartialy(int n1, int m1, int n2, int m2)
    {
        for (int i = n1; i < n2; i++)
        {
         
            for (int j = m1; j < m2; j++)
            {
                Console.Write($"{matrix[i, j]}" + " ");
                if (i == n2 && j == m2)
                    break;
            }
            Console.WriteLine();
            
        }

        Console.WriteLine();
    }

    public void Show()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write($"{matrix[i, j]}" + " ");
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public int this[int i, int j]
    {
        get
        {
            if (i < 0 || j < 0 || i >= n || j >= m)
            {
                throw new IndexOutOfRangeException();
            }


            else
            {
                return matrix[i, j];
            }
        }

        set
        {
            if (i < 0 || j < 0 || i >= n || j >= m)
            {
                throw new IndexOutOfRangeException();
            }

            else
            {
                matrix[i, j] = value;
            }
        }
    }
}

class Program
{
    static void Main(string[] args){
        MyMatrix matrix = new MyMatrix(3, 4, 2, 5);

        Console.WriteLine("Изначальная матрица:");
        matrix.Show();

        matrix.Fill(6, 10);
        Console.WriteLine("Перезаполненная матрица:");
        matrix.Show();

        MyMatrix matrix2 = matrix.ChangeSize(5, 10);
        Console.WriteLine("Матрица с измененным количеством строк и столбцов:");
        matrix2.Show();

        Console.WriteLine("Частично выведенная матрица:");
        matrix2.ShowPartialy(2, 3, 4, 7);
    }
}