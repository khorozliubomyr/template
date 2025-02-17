
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    class States
    {
        public enum State
        {
            [Description("Alabama")] AL = 1,
            [Description("Alaska")] AK = 2,
            [Description("Arkansas")] AR = 3,
            [Description("Arizona")] AZ = 4,
            [Description("California")] CA = 5,
            [Description("Colorado")] CO = 6,
            [Description("Connecticut")] CT = 7,
            [Description("D.C.")] DC = 8,
            [Description("Delaware")] DE = 9,
            [Description("Florida")] FL = 10, // 0x0000000A
            [Description("Georgia")] GA = 11, // 0x0000000B
            [Description("Hawaii")] HI = 12, // 0x0000000C
            [Description("Iowa")] IA = 13, // 0x0000000D
            [Description("Idaho")] ID = 14, // 0x0000000E
            [Description("Illinois")] IL = 15, // 0x0000000F
            [Description("Indiana")] IN = 16, // 0x00000010
            [Description("Kansas")] KS = 17, // 0x00000011
            [Description("Kentucky")] KY = 18, // 0x00000012
            [Description("Louisiana")] LA = 19, // 0x00000013
            [Description("Massachusetts")] MA = 20, // 0x00000014
            [Description("Maryland")] MD = 21, // 0x00000015
            [Description("Maine")] ME = 22, // 0x00000016
            [Description("Michigan")] MI = 23, // 0x00000017
            [Description("Minnesota")] MN = 24, // 0x00000018
            [Description("Missouri")] MO = 25, // 0x00000019
            [Description("Mississippi")] MS = 26, // 0x0000001A
            [Description("Montana")] MT = 27, // 0x0000001B
            [Description("North Carolina")] NC = 28, // 0x0000001C
            [Description("North Dakota")] ND = 29, // 0x0000001D
            [Description("Nebraska")] NE = 30, // 0x0000001E
            [Description("New Hampshire")] NH = 31, // 0x0000001F
            [Description("New Jersey")] NJ = 32, // 0x00000020
            [Description("New Mexico")] NM = 33, // 0x00000021
            [Description("Nevada")] NV = 34, // 0x00000022
            [Description("New York")] NY = 35, // 0x00000023
            [Description("Oklahoma")] OK = 36, // 0x00000024
            [Description("Ohio")] OH = 37, // 0x00000025
            [Description("Oregon")] OR = 38, // 0x00000026
            [Description("Pennsylvania")] PA = 39, // 0x00000027
            [Description("Puerto Rico")] PR = 40, // 0x00000028
            [Description("Rhode Island")] RI = 41, // 0x00000029
            [Description("South Carolina")] SC = 42, // 0x0000002A
            [Description("South Dakota")] SD = 43, // 0x0000002B
            [Description("Tennessee")] TN = 45, // 0x0000002D
            [Description("Texas")] TX = 46, // 0x0000002E
            [Description("Utah")] UT = 47, // 0x0000002F
            [Description("Virginia")] VA = 48, // 0x00000030
            [Description("Vermont")] VT = 49, // 0x00000031
            [Description("Washington")] WA = 50, // 0x00000032
            [Description("Wisconsin")] WI = 51, // 0x00000033
            [Description("West Virginia")] WV = 52, // 0x00000034
            [Description("Wyoming")] WY = 53, // 0x00000035
        }
    }
}
