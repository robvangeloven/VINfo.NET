﻿using System;
using VINfo.Resources;

namespace VINfo
{
    public class VINData
    {
        public string OriginalVIN { get; internal set; }

        public bool HasValidCheckDigit { get; internal set; }

        public Region Region { get; internal set; }

        public string Country { get; internal set; }

        private VINData(string vin)
        {
            OriginalVIN = vin;
        }

        private static int Transliterate(char c)
        {
            return "0123456789.ABCDEFGH..JKLMN.P.R..STUVWXYZ".IndexOf(c) % 10;
        }

        private static char GetCheckDigit(string vin)
        {
            string map = "0123456789X";
            int[] weights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < 17; ++i)
            {
                sum += Transliterate(vin[i]) * weights[i];
            }

            return map[sum % 11];
        }

        public static bool IsValid(string vin)
        {
            if (vin?.Length != 17) return false;

            return GetCheckDigit(vin) == vin[8];
        }

        public static VINData Parse(string vin)
        {
            if (!IsValid(vin)) throw new ArgumentException($"VIN '{vin}' is not a valid VIN", nameof(vin));

            var vinData = new VINData(vin);

            switch (vin[0])
            {
                case 'A':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'H')
                    {
                        vinData.Country = Countries.SouthAfrica;
                        break;
                    }


                    if ('I' <= vin[1] && vin[1] <= 'N')
                    {
                        vinData.Country = Countries.IvoryCoast;
                        break;
                    }
                    break;

                case 'B':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'E')
                    {
                        vinData.Country = Countries.Angola;
                        break;
                    }

                    if ('F' <= vin[1] && vin[1] <= 'K')
                    {
                        vinData.Country = Countries.Kenya;
                    }

                    if ('L' <= vin[1] && vin[1] <= 'R')
                    {
                        vinData.Country = Countries.Tanzania;
                    }
                    break;

                case 'C':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'E')
                    {
                        vinData.Country = Countries.Benin;
                        break;
                    }

                    if ('F' <= vin[1] && vin[1] <= 'K')
                    {
                        vinData.Country = Countries.Madagascar;
                    }

                    if ('L' <= vin[1] && vin[1] <= 'R')
                    {
                        vinData.Country = Countries.Tunisia;
                    }
                    break;

                case 'D':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'E')
                    {
                        vinData.Country = Countries.Egypt;
                        break;
                    }

                    if ('F' <= vin[1] && vin[1] <= 'K')
                    {
                        vinData.Country = Countries.Morocco;
                    }

                    if ('L' <= vin[1] && vin[1] <= 'R')
                    {
                        vinData.Country = Countries.Zambia;
                    }
                    break;

                case 'E':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'E')
                    {
                        vinData.Country = Countries.Ethiopia;
                        break;
                    }

                    if ('F' <= vin[1] && vin[1] <= 'K')
                    {
                        vinData.Country = Countries.Mozambique;
                    }
                    break;

                case 'F':
                    vinData.Region = Region.Africa;

                    if ('A' <= vin[1] && vin[1] <= 'E')
                    {
                        vinData.Country = Countries.Ghana;
                        break;
                    }

                    if ('F' <= vin[1] && vin[1] <= 'K')
                    {
                        vinData.Country = Countries.Nigeria;
                    }
                    break;
            }

            return vinData;
        }
    }
}
