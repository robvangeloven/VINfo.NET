﻿using System.Collections.Generic;
using System.Collections.Immutable;

namespace VINfo
{
    public class WorldManufacturerIdentifier
    {
        ImmutableDictionary<char, int> chars = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['B'] = 1,
            ['C'] = 2,
            ['D'] = 3,
            ['E'] = 4,
            ['F'] = 5,
            ['G'] = 6,
            ['H'] = 7,
            ['J'] = 9,
            ['K'] = 10,
            ['L'] = 11,
            ['M'] = 12,
            ['N'] = 13,
            ['P'] = 15,
            ['R'] = 16,
            ['S'] = 18,
            ['T'] = 19,
            ['U'] = 20,
            ['V'] = 21,
            ['W'] = 22,
            ['X'] = 23,
            ['Y'] = 24,
            ['Z'] = 25,
            ['1'] = 26,
            ['2'] = 27,
            ['3'] = 28,
            ['4'] = 29,
            ['5'] = 30,
            ['6'] = 31,
            ['7'] = 32,
            ['8'] = 33,
            ['9'] = 34,
            ['0'] = 35
        }.ToImmutableDictionary();



        public Region Region { get; private set; }

        public string Country { get; private set; }

        public string Manufacturer { get; }




        public static Region ToRegion(char code)
        {
            if ('A' <= code && code <= 'H') return Region.Africa;
            if ('J' <= code && code <= 'R') return Region.Asia;
            if ('S' <= code && code <= 'Z') return Region.Africa;
            if ('A' <= code && code <= 'H') return Region.Africa;
            if ('A' <= code && code <= 'H') return Region.Africa;
            if ('A' <= code && code <= 'H') return Region.Africa;

            return Region.Asia;

        }
    }
}
