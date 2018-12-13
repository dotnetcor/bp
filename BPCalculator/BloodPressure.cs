using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low = 1,
        [Display(Name = "Normal Blood Pressure")] Normal = 2,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh = 3,
        [Display(Name = "High Blood Pressure")] High = 4
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        public string HealthTip { get; set; }

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }      // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                Dictionary<double, BPCategory> Systoliclevels = new Dictionary<double, BPCategory>
    {
        {0d,BPCategory.Low },
        {90d, BPCategory.Normal},
        {120d, BPCategory.PreHigh},
        {140d, BPCategory.High}

        };
                Dictionary<double, BPCategory> Diastoliclevels = new Dictionary<double, BPCategory>
    {
        {0d, BPCategory.Low},
        {60d, BPCategory.Normal},
        {80d, BPCategory.PreHigh},
        {90d, BPCategory.High}

        };
                // Create a list for matched values (of enums)
                List<BPCategory> s = new List<BPCategory>();

                // Find the matched classification of the Sistolic level
                foreach (var element in Systoliclevels.Keys)
                {
                    if (Systolic >= element)
                        s.Add(Systoliclevels[element]);
                }

                // Find the matched classification of the Diastolic level
                foreach (var element in Diastoliclevels.Keys)
                {
                    if (Diastolic >= element)
                        s.Add(Diastoliclevels[element]);
                }

                CalculateHealthTip(s.ToArray().Max());

                // Return the highest classification (enum)
                return s.ToArray().Max();

            }
        }

        private void CalculateHealthTip(BPCategory bPCategory)
        {
            switch (bPCategory) {
                case BPCategory.Normal:
                    this.HealthTip = "Keep up the good work!";
                        break;
                case BPCategory.Low:
                    this.HealthTip = "TIP: Factor some salt into your diet, eat healthy fruits and grains and consult a physician.";
                    break;
                case BPCategory.PreHigh:
                    this.HealthTip = "TIP: Reduce weight, increase exercise and reduce alcohol consumption.";
                    break;
                case BPCategory.High:
                    this.HealthTip = "Consult a physician.";
                    break;
                default:
           
                    this.HealthTip = "";
                
                    break;

            }
        }
    }
}
