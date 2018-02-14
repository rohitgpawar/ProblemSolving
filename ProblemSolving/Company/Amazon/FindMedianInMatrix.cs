/*
 
 Your job is to create a service that will store metrics and at any time can be used to get back a median in O(1)
 */

namespace ProblemSolving
{
    public class FindMedianInMatrix
    {
        public static void FindMedianInMatrixMain()
        {
            int[] values = new int[] { 16,15,1,6,7,8,13,14, 2, 3, 4, 5, 9,10,11,12 };
            MyMatrix mat = new MyMatrix(4);
            mat.Insert(values);
            float median = mat.GetMedian();
        }
        
    }

    public class MyMatrix
    {
        private int _size;
        public int[][] matrix;
        public MaxHeap maxHeap;
        public MyMatrix(int size)
        {
            _size = size;
            matrix = new int[_size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new int[_size];
            }
        }

        public float GetMedian()
        {
           return maxHeap.GetMax();
        }

        public void Insert(int[] values)
        {
            if(values.Length != _size*_size)
            {
                return;
            }
            int length = (_size % 2 == 0) ? _size * 2 + 1 : _size * 2 - 1;
            maxHeap = new MaxHeap(length);

            int row = 0;
            int col = 0;
            for(int i=0;i<values.Length;i++)
            {
                if(col == _size)
                {
                    row++;
                    col = 0;
                }
                matrix[row][col] = values[i];
                InsertForMedianProblem(values[i]);
                col++;
            }
            if(_size % 2 == 0)
            {//IsEven
                float maxVal = maxHeap.GetMax();
                maxVal += maxHeap.GetMax();
                maxHeap.Insert(maxVal / 2);
            }
        }

        public void InsertForMedianProblem(int val)
        {
            //if (val < maxHeap.heap[0] || maxHeap.size==0)
            {//Value in Limits
                if (maxHeap.size == maxHeap.cap && val < maxHeap.heap[0])
                {//If heap if full then remove Max element.
                    maxHeap.GetMax();
                    maxHeap.Insert(val);
                }
                else if(maxHeap.size < maxHeap.cap)
                    maxHeap.Insert(val);
            }
        }
    }
}
