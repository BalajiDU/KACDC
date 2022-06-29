using KACDC.Class.Declaration.Aadhaar;
using KACDC.Class.Declaration.Nadakacheri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KACDC.Class.DataProcessing.ApplicationProcess
{
    public class CheckNameSimilarity
    {
        public bool VerifySimilarities(string PWD="")
        {
            NadaKacheri NKSER = new NadaKacheri();
            NadakacheriPWD NKPWD = new NadakacheriPWD();
            AadhaarServiceData ADSER = new AadhaarServiceData();
            if (PWD == "")
            {
                if (Int32.Parse(NKSER.NCLanguage) == 1)
                {
                    if (CalculateSimilarity(ADSER.KannadaName, NKSER.NCApplicantName) >= 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (CalculateSimilarity(ADSER.Name.ToUpper(), NKSER.NCApplicantName.ToUpper()) > 0.7)
                    {
                        return true;
                    }
                    return false;
                }
            }
            if (PWD != "")
            {
                if (Int32.Parse(NKPWD.NCLanguage) == 1)
                {
                    if (CalculateSimilarity(ADSER.KannadaName, NKPWD.NCApplicantName) >= 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    if (CalculateSimilarity(ADSER.Name.ToUpper(), NKPWD.NCApplicantName.ToUpper()) > 0.7)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public  double CalculateSimilarity(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 1 : 0;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 1 : 0;

            double stepsToSame = ComputeLevenshteinDistance(source, target);
            //return stepsToSame;
            return (1.0 - (stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        private  int ComputeLevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 0 : source.Length;

            int sourceLength = source.Length;
            int targetLength = target.Length;

            int[,] distance = new int[sourceLength + 1, targetLength + 1];

            // Step 1
            for (int i = 0; i <= sourceLength; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetLength; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceLength; i++)
            {
                for (int j = 1; j <= targetLength; j++)
                {
                    // Step 2
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 3
                    distance[i, j] = Math.Min(
                                        Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                                        distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceLength, targetLength];
        }
    }
}