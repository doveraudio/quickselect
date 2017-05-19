using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 6, 4, 7, 3, 0, 8, 2, 9, 1, 5 };
            for (int i = 0; i < arr.Length; i++) {
                Console.WriteLine("{0}th value is {1}; ", i, selectKth(arr, i));
            }
            Console.ReadLine();
        }

        public static int selectKth(int[] arr, int k) {

            if (arr == null || arr.Length <= k) {
                throw new System.ArgumentException("Array Parameter cannot be less than k or NULL", "original");
            }
            int from = 0;
            int to = arr.Length - 1;
            // if from ==  to, we reached the kth element
            while (from < to) {
                // reader, checks the value position
                int r = from;
                // writer, gets the value from the reader, when it is larger
                //         than the pivot (middle of the searched segment)
                int w = to;
                // find the middle of the segment we are searching
                int mid = arr[(r + w) / 2];
                // we stop when the reader and write meet.
                while (r < w) {
                    // check if the value in the current read node is larger than the middle
                    if (arr[r] >= mid)
                    {
                        // swap the read/write nodes when comparison passes
                        int tmp = arr[w];
                        arr[w] = arr[r];
                        arr[r] = tmp;
                        // Decrement the write node, and continue the comparisons, swapping when necessary
                        w--;
                    }
                    else {
                        // in the case that the read node is less than the middle value, increment the read node up one segment, we can't do anything.
                        r++;
                    } // end comparison
                }// end while(r<w) loop, r == w;
                // check if read node is greater than middle value, if so, traverse back
                if (arr[r] > mid) {
                    r--;
                }
                // check if r has reached k
                if (k <= r)
                {
                    // if r is at k, or not yet, setup for at least one more swap.
                    to = r;

                }
                else {
                    // when k is still greater than r, we will keep moving the read node up.
                    from = r + 1;
                }
            }
            // we have sorted our segment and found the kth number in the series. return it.
            return arr[k];
        }

        /*
         public static int selectKth(int[] arr, int k) {
 if (arr == null || arr.length <= k)
  throw new Error();
 
 int from = 0, to = arr.length - 1;
 
 // if from == to we reached the kth element
 while (from < to) {
  int r = from, w = to;
  int mid = arr[(r + w) / 2];
 
  // stop if the reader and writer meets
  while (r < w) {
 
   if (arr[r] >= mid) { // put the large values at the end
    int tmp = arr[w];
    arr[w] = arr[r];
    arr[r] = tmp;
    w--;
   } else { // the value is smaller than the pivot, skip
    r++;
   }
  }
 
  // if we stepped up (r++) we need to step one down
  if (arr[r] > mid)
   r--;
 
  // the r pointer is on the end of the first k elements
  if (k <= r) {
   to = r;
  } else {
   from = r + 1;
  }
 }
 
 return arr[k];
}
         */

    }
}
