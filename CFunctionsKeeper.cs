using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wf_metr_lab3
{
    static class CFunctionsKeeper
    {
        public static int BucketSearch(double[] aSequence, double fSearched, int iCountOfBuckets)
        {
            int iSearchedIndex = -1;
            Assert.IsTrue(aSequence.Length.CompareTo(0).Equals(1));
            Assert.IsTrue(CheckDataIsCorrect(aSequence));
            int iSizeOfBucket = aSequence.Length / iCountOfBuckets;
            for (int i = 0; i < iCountOfBuckets - 1; i++)
            {
                int iStart = i * iSizeOfBucket,
                    iFinish = i * iSizeOfBucket + iSizeOfBucket;
                if (CheckBucket(i, iCountOfBuckets, aSequence, fSearched))
                {
                    iSearchedIndex = SearchInBucket(iStart, iFinish, fSearched, aSequence);
                    break;
                }
            }
            if (iSearchedIndex == -1)
            {
                iSearchedIndex = SearchInBucket((iCountOfBuckets-1) * iSizeOfBucket, aSequence.Length, 
                    fSearched, aSequence);
            }
            return iSearchedIndex;
        }
        public static double[] SelectionSort(double[] aSequence)
        {
            Assert.IsTrue(aSequence.Length.CompareTo(0).Equals(1));
            double[] aSortedSequence = new double[aSequence.Length];
            for (int i = 0; i < aSequence.Length - 1; i++)
            {
                int iMinIndex = FindIndexOfMin(i, aSequence);
                aSortedSequence = SwapElements(iMinIndex, i, aSequence);
            }
            return aSortedSequence;
        }
        private static int FindIndexOfMin (int iStart, double[] aSequence)
        {
            int iMinIndex = iStart;
            double fMin = aSequence[iStart];
            for (int i = iStart+1; i < aSequence.Length; i++)
            {
                if (aSequence[i]<fMin)
                {
                    fMin = aSequence[i];
                    iMinIndex = i;
                }
            }
            return iMinIndex;
        }
        private static double[] SwapElements (int iFirst, int iSecond, double[] aSequence)
        {
            double fTemp = aSequence[iFirst];
            aSequence[iFirst] = aSequence[iSecond];
            aSequence[iSecond] = fTemp;
            return aSequence;
        }
        private static bool CheckDataIsCorrect(double[] aSequence)
        {
            bool bIsCorrect = true;
            for (int i = 0; i < aSequence.Length-1; i++)
            {
                if (aSequence[i] > aSequence[i+1])
                {
                    bIsCorrect = false;
                    break;
                }
            }           
            return bIsCorrect;
        }
        private static bool CheckBucket(int iNumberOfBucket, int iCountOfBuckets, double[] aSequence, double fSearched)
        {
            bool bIsFind = false;
            int iSizeOfBucket = aSequence.Length / iCountOfBuckets,
                iStart = iNumberOfBucket * iSizeOfBucket,
                iFinish = iNumberOfBucket * iSizeOfBucket + iSizeOfBucket;
            if (fSearched>=aSequence[iStart] && fSearched <= aSequence[iFinish])
            {
                bIsFind = true;
            }
            return bIsFind;
        }
        private static int SearchInBucket(int iStart, int iFinish, double fSearched, double[] aSequence)
        {
            int iNumberOfFinded = 0;
            for (int i = iStart; i < iFinish; i++)
            {
                if (fSearched==aSequence[i])
                {
                    iNumberOfFinded = i;
                    break;
                }
            }
            return iNumberOfFinded;
        }

    }
}
