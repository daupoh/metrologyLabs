using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf_metr_lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int iLength = 5;
            char[] aSymbols = new char[] {'a','b','c','d','e' };
            double[] aProbabilities = new double[] { 0.02, 0.25, 0.08, 0.35, 0.3 };
            CPair[] aPairs = new CPair[iLength];
            for (int i = 0; i < iLength; i++)
            {
                aPairs[i] = new CPair(aSymbols[i].ToString(), aProbabilities[i]);
            }
            aPairs = CFunctionsKeeper.HaffmanCode(aPairs);
            string str = "";
            foreach(CPair rPair in aPairs)
            {
                str+="Symbol " +rPair.Symbols+" with probability "
                    +rPair.Probability.ToString()+" has code "+rPair.Codes+"\r\n";
            }
            MessageBox.Show(str);
        }        
    }
}
