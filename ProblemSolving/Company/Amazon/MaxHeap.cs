/*
 Implementing Max Heap
 */

namespace ProblemSolving
{
    public class MaxHeap
    {
        public float[] heap;
        public int size;
        public int cap;
        public MaxHeap(int cap)
        {
            this.cap= cap;
            heap = new float[this.cap];
        }

        /// <summary>
        /// Insert element in Max heap
        /// </summary>
        /// <param name="i"></param>
        public void Insert(float i)
        {
            size++;
            int position = size - 1;
            heap[position] = i;
            while(position !=0 && heap[Parent(position)] < i)
            {//Move item to it's parent
                float temp = heap[position];
                heap[position] = heap[Parent(position)];
                heap[Parent(position)] = temp;
                position = Parent(position);
            }
        }



        /// <summary>
        /// Fetch max value from heap
        /// </summary>
        /// <returns></returns>
        public float GetMax()
        {
            if(size ==1)
            {//If only 1 element return top
                //_size--;
                return heap[0];
            }

            float max = heap[0];
            heap[0] = heap[size - 1];//Replace first with last element
            size--;
            MaxHeapify(0);
            return max;
        }


        /// <summary>
        /// Max heapify starting from a position.
        /// </summary>
        /// <param name="position"></param>
        public void MaxHeapify(int position)
        {
            int leftVal = 2 * position + 1;
            int rightVal =2 * position + 2;

            int maxVal = position;

            if (leftVal < size && heap[leftVal] > heap[maxVal])
            {//Left child is Larger 
                maxVal = leftVal;
            }

            if( rightVal < size && heap[rightVal] > heap[maxVal])
            {//Right child has highest value
                maxVal = rightVal;
            }
            
            if(maxVal != position)
            {//Swap position and maxVal
                float temp = heap[maxVal];
                heap[maxVal] = heap[position];
                heap[position] = temp;

                MaxHeapify(maxVal);
            }
        }

        /// <summary>
        /// Return parent of current position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private int Parent(int position)
        {
            return ((position - 1) / 2);
        }

    }
}
