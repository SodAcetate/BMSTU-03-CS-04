using System;

namespace Lab_04_1
{   
    class Program
    {   
        static int min=1;
        static int max=100;
        class MyMatrix
        {
            double[][] matrix;

            public int height {get; set;}
            public int width {get; set;}
            public MyMatrix(int m, int n){
                height = m;
                width = n;
                Random rng = new Random();
                matrix = new double[m][];
                for (int i = 0 ; i < m ; i++){
                    matrix[i] = new double[n];
                    for (int j = 0 ; j < n ; j ++){
                        matrix[i][j] = rng.Next(min, max);
                    }
                }
            }

            public void print(){
                Console.Write("\n");
                for (int i = 0 ; i < height ; i ++){
                    for (int j = 0 ; j < width ; j ++){
                        Console.Write($"{matrix[i][j]}\t");
                    }
                    Console.Write("\n");
                }
            }

            public double this[int i, int j]{
                get => matrix[i][j];
                set => matrix[i][j] = value;
            }

            public static MyMatrix operator+(MyMatrix A, MyMatrix B){
                if (A.height != B.height || A.width != B.width){
                    throw new Exception("Matrix are of different size");
                }
                else{
                    MyMatrix result = new MyMatrix(A.height, A.width);
                    for (int i = 0 ; i < A.height ; i ++){
                        for (int j = 0 ; j < A.width ; j ++){
                            result[i,j] = A[i,j] + B[i,j];
                        }
                    }
                    return result;   
                }
            }

            public static MyMatrix operator-(MyMatrix A, MyMatrix B){
                if (A.height != B.height || A.width != B.width){
                    throw new Exception("Matrix are of different size");
                }
                else{
                    MyMatrix result = new MyMatrix(A.height, A.width);
                    for (int i = 0 ; i < A.height ; i ++){
                        for (int j = 0 ; j < A.width ; j ++){
                            result[i,j] = A[i,j] - B[i,j];
                        }
                    }
                    return result;   
                }
            }
            public static MyMatrix operator*(MyMatrix A, MyMatrix B){
                if (A.width != B.height){
                    throw new Exception("Matrix are of different size");
                }
                else{
                    MyMatrix result = new MyMatrix(A.height, B.width);
                    for (int i = 0 ; i < A.height ; i ++){
                        for (int j = 0 ; j < B.width ; j ++){
                            result[i,j]=0;
                            for (int k = 0 ; k < A.width ; k ++){
                                result[i,j] += A[i,k] * B[k,j];
                            }
                        }
                    }
                    return result;   
                }
            }
            public static MyMatrix operator*(MyMatrix A, double k){
                MyMatrix result = new MyMatrix(A.height, A.width);
                for (int i = 0 ; i < A.height ; i ++){
                    for (int j = 0 ; j < A.width ; j ++){
                        result[i,j] = A[i,j] * k;                            
                    }
                }
                return result;   
            }
            public static MyMatrix operator*(double k, MyMatrix A){
                return A * k;   
            }
            public static MyMatrix operator/(MyMatrix A, double k){
                MyMatrix result = new MyMatrix(A.height, A.width);
                for (int i = 0 ; i < A.height ; i ++){
                    for (int j = 0 ; j < A.width ; j ++){
                        result[i,j] = A[i,j] / k;                            
                    }
                }
                return result;   
            }
            public static MyMatrix operator/(double k, MyMatrix A){
                return A / k;   
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter min value:");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter max value:");
            max = Convert.ToInt32(Console.ReadLine())+1;
            Console.WriteLine("Gotchu");

            MyMatrix testMatrixA = new MyMatrix(3,3);
            MyMatrix testMatrixB = new MyMatrix(3,3);
            testMatrixA.print();
            testMatrixB.print();
            MyMatrix testMatrixC = testMatrixA * testMatrixB;
            testMatrixC.print();
            testMatrixA = 4*testMatrixC;
            testMatrixA.print();
            testMatrixB = testMatrixA/4;
            testMatrixB.print();
            testMatrixC = testMatrixC-testMatrixB;
            testMatrixC.print();

        }
    }
}