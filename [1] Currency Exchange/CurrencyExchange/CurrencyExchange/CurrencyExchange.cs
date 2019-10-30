using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    // *****************************************
    // DON"T CHANGE CLASS NAME OR FUNCTION NAME
    // *****************************************
    public static class CurrencyExchange
    {
        //Your Code is Here:
        //==================
        /// <summary>
        /// find the index of the USD Dollar $ with the smallest number of questions.
        /// </summary>
        /// <param name="N">Number of customers (N)</param>
        /// <param name="M">Number of currencies (M)</param>
        /// <param name="knows">N*M Matrix indicating whether customer i knows currency j or not</param>
        /// <returns>index of US Dollar</returns>
        public static int CheckUSD(int N, int M, bool[,] knows)
        {

            return searchTrue(knows,N,M,0,0);
        }
        public static int searchTrue(bool[,] arr,int N, int M,int row,int col)
        {
            if(row == N - 1 && arr[row,col] == true)
            {
                return col;
            }
            else if (arr[row, col])
            {
                row++;
                return searchTrue(arr, N, M, row, col);
            }
            else if (!arr[row, col])
            {
                col++;
                return searchTrue(arr, N, M, row, col);
            }

            return -1;
        }
        

        }
    }
