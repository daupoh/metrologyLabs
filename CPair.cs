using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace wf_metr_lab3
{
    class CPair
    {
        string sSymbols="", sCodes="";
        double fProbability=0;

        CPair rLeftSon, rRightSon, rParent;

        public CPair(string sSymbols, double fProbability)
        {
            Assert.IsTrue(sSymbols.Length.CompareTo(0).Equals(1));
            Assert.IsTrue(fProbability.CompareTo(0).Equals(1));
            this.sSymbols = sSymbols;
            this.fProbability = fProbability;
            rLeftSon = null;
            rRightSon = null;
            rParent = null;
        }
        public CPair(CPair rLeftSon, CPair rRightSon)
        {
            this.sSymbols = rLeftSon.Symbols + rRightSon.Symbols;
            this.fProbability = rLeftSon.Probability + rRightSon.Probability; 
            rLeftSon.UpdateCodes("1");
            rRightSon.UpdateCodes("0");
            this.rLeftSon = rLeftSon;
            this.rRightSon = rRightSon;
            this.rLeftSon.rParent = this;
            this.rRightSon.rParent = this;
        }
        public void Copy(CPair rCopied)
        {
            sSymbols = rCopied.Symbols;
            sCodes = rCopied.Codes;
            fProbability = rCopied.Probability;
            rLeftSon = rCopied.rLeftSon;
            rRightSon = rCopied.rRightSon;
            rParent = rCopied.rParent;
        }
        public string Symbols
        {
            get
            {
                return sSymbols;
            }
        }
        public double Probability
        {
            get
            {
                return fProbability;
            }
        }
        public string Codes
        {
            get
            {
                return sCodes;
            }
        }
        public CPair[] Leafs
        {
            get
            {
                List<CPair> aLeafs = new List<CPair>();
                GetLeaf(aLeafs);
                return aLeafs.ToArray();
            }
        }
      
        private void UpdateCodes(string cCode)
        {
            sCodes = cCode+sCodes;
            if (rLeftSon!=null)
            {              
                rLeftSon.UpdateCodes(cCode);
            }
            if (rRightSon != null)
            {             
                rRightSon.UpdateCodes(cCode);
            }
        }    
        private void GetLeaf(List<CPair> aLeafs)
        {
            if (rLeftSon==null && rRightSon==null)
            {
                aLeafs.Add(this);
            }
            else
            {
                if (rLeftSon != null)
                {
                    rLeftSon.GetLeaf(aLeafs);
                }
                if (rRightSon != null)
                {
                    rRightSon.GetLeaf(aLeafs);
                }
            }
        }
    }
}
