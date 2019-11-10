using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace wf_metr_lab3
{
    static class CFunctionsKeeper
    {       
        public static CPair[] HaffmanCode(CPair[] aSequence)
        {    
            Assert.IsTrue(aSequence.Length.CompareTo(2).Equals(1));
            List<CPair> aTreeCodes = new List<CPair>();
            foreach(CPair rPair in aSequence)
            {
                aTreeCodes.Add(rPair);
            }
            while (aTreeCodes.Count != 1)
            {
                CPair rFirstMin = FindAndDeleteMinProbability(aTreeCodes),
                    rSecondMin = FindAndDeleteMinProbability(aTreeCodes);              
                CPair rNewRoot = new CPair(rFirstMin, rSecondMin);                
                aTreeCodes.Add(rNewRoot);
            }
            return aTreeCodes[0].Leafs;
        }
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
        private static CPair FindAndDeleteMinProbability(List<CPair> aCodes)
        {
            CPair fMin = new CPair("TempSymp",double.MaxValue);
            int iNumberOfMin = -1;
            for (int i = 0; i < aCodes.Count; i++)
            {
                if (aCodes[i].Probability < fMin.Probability)
                {
                    fMin.Copy(aCodes[i]);
                    iNumberOfMin = i;
                }
            }
            aCodes.RemoveAt(iNumberOfMin);
            return fMin;
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
