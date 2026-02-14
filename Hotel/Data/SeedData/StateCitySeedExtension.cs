
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data.SeedData
{
    public static class StateCitySeedExtension
    {
        public static void SeedStatesAndCities(this ModelBuilder modelBuilder)
        {
            SeedStates(modelBuilder);
            SeedCities(modelBuilder);
        }

        private static void SeedStates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblState>().HasData(
                new TblState { StateID = 1, StateCode = "AP", StateName = "Andhra Pradesh" },
                new TblState { StateID = 2, StateCode = "AR", StateName = "Arunachal Pradesh" },
                new TblState { StateID = 3, StateCode = "AS", StateName = "Assam" },
                new TblState { StateID = 4, StateCode = "BR", StateName = "Bihar" },
                new TblState { StateID = 5, StateCode = "CG", StateName = "Chhattisgarh" },
                new TblState { StateID = 6, StateCode = "GA", StateName = "Goa" },
                new TblState { StateID = 7, StateCode = "GJ", StateName = "Gujarat" },
                new TblState { StateID = 8, StateCode = "HR", StateName = "Haryana" },
                new TblState { StateID = 9, StateCode = "HP", StateName = "Himachal Pradesh" },
                new TblState { StateID = 10, StateCode = "JH", StateName = "Jharkhand" },
                new TblState { StateID = 11, StateCode = "KA", StateName = "Karnataka" },
                new TblState { StateID = 12, StateCode = "KL", StateName = "Kerala" },
                new TblState { StateID = 13, StateCode = "MP", StateName = "Madhya Pradesh" },
                new TblState { StateID = 14, StateCode = "MH", StateName = "Maharashtra" },
                new TblState { StateID = 15, StateCode = "MN", StateName = "Manipur" },
                new TblState { StateID = 16, StateCode = "ML", StateName = "Meghalaya" },
                new TblState { StateID = 17, StateCode = "MZ", StateName = "Mizoram" },
                new TblState { StateID = 18, StateCode = "NL", StateName = "Nagaland" },
                new TblState { StateID = 19, StateCode = "OD", StateName = "Odisha" },
                new TblState { StateID = 20, StateCode = "PB", StateName = "Punjab" },
                new TblState { StateID = 21, StateCode = "RJ", StateName = "Rajasthan" },
                new TblState { StateID = 22, StateCode = "SK", StateName = "Sikkim" },
                new TblState { StateID = 23, StateCode = "TN", StateName = "Tamil Nadu" },
                new TblState { StateID = 24, StateCode = "TS", StateName = "Telangana" },
                new TblState { StateID = 25, StateCode = "TR", StateName = "Tripura" },
                new TblState { StateID = 26, StateCode = "UP", StateName = "Uttar Pradesh" },
                new TblState { StateID = 27, StateCode = "UK", StateName = "Uttarakhand" },
                new TblState { StateID = 28, StateCode = "WB", StateName = "West Bengal" },
                new TblState { StateID = 29, StateCode = "DL", StateName = "Delhi" },
                new TblState { StateID = 30, StateCode = "JK", StateName = "Jammu and Kashmir" },
                new TblState { StateID = 31, StateCode = "LA", StateName = "Ladakh" },
                new TblState { StateID = 32, StateCode = "CH", StateName = "Chandigarh" },
                new TblState { StateID = 33, StateCode = "PY", StateName = "Puducherry" },
                new TblState { StateID = 34, StateCode = "AN", StateName = "Andaman and Nicobar Islands" },
                new TblState { StateID = 35, StateCode = "LD", StateName = "Lakshadweep" },
                new TblState { StateID = 36, StateCode = "DN", StateName = "Dadra and Nagar Haveli and Daman and Diu" }
            );
        }

        private static void SeedCities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCity>().HasData(
                new TblCity { CityID = 1, CityName = "Visakhapatnam", StateID = 1 },
                new TblCity { CityID = 2, CityName = "Vijayawada", StateID = 1 },
                new TblCity { CityID = 3, CityName = "Guntur", StateID = 1 },
                new TblCity { CityID = 4, CityName = "Nellore", StateID = 1 },
                new TblCity { CityID = 5, CityName = "Kurnool", StateID = 1 },

                // 👉 continue remaining cities here
                new TblCity { CityID = 6, CityName = "Hyderabad", StateID = 24 },
                new TblCity { CityID = 7, CityName = "Warangal", StateID = 24 },
                new TblCity { CityID = 8, CityName = "Nizamabad", StateID = 24 },
                new TblCity { CityID = 9, CityName = "Karimnagar", StateID = 24 },

                new TblCity { CityID = 10, CityName = "Mumbai", StateID = 14 },
                new TblCity { CityID = 11, CityName = "Pune", StateID = 14 },
                new TblCity { CityID = 12, CityName = "Nagpur", StateID = 14 },
                new TblCity { CityID = 13, CityName = "Nashik", StateID = 14 },
                new TblCity { CityID = 14, CityName = "Aurangabad", StateID = 14 },

                new TblCity { CityID = 15, CityName = "Ahmedabad", StateID = 7 },
                new TblCity { CityID = 16, CityName = "Surat", StateID = 7 },
                new TblCity { CityID = 17, CityName = "Vadodara", StateID = 7 },
                new TblCity { CityID = 18, CityName = "Rajkot", StateID = 7 },
                new TblCity { CityID = 19, CityName = "Bhavnagar", StateID = 7 },
                new TblCity { CityID = 20, CityName = "Jamnagar", StateID = 7 },
                new TblCity { CityID = 21, CityName = "Junagadh", StateID = 7 },
                new TblCity { CityID = 22, CityName = "Gandhinagar", StateID = 7 },
                new TblCity { CityID = 23, CityName = "Anand", StateID = 7 },
                new TblCity { CityID = 24, CityName = "Morbi", StateID = 7 },
                new TblCity { CityID = 25, CityName = "Mehsana", StateID = 7 },
                new TblCity { CityID = 26, CityName = "Nadiad", StateID = 7 },
                new TblCity { CityID = 27, CityName = "Bharuch", StateID = 7 },
                new TblCity { CityID = 28, CityName = "Vapi", StateID = 7 },
                new TblCity { CityID = 29, CityName = "Porbandar", StateID = 7 },

                new TblCity { CityID = 30, CityName = "Jaipur", StateID = 21 },
                new TblCity { CityID = 31, CityName = "Jodhpur", StateID = 21 },
                new TblCity { CityID = 32, CityName = "Udaipur", StateID = 21 },
                new TblCity { CityID = 33, CityName = "Kota", StateID = 21 },
                new TblCity { CityID = 34, CityName = "Ajmer", StateID = 21 },
                new TblCity { CityID = 35, CityName = "Bikaner", StateID = 21 },
                new TblCity { CityID = 36, CityName = "Alwar", StateID = 21 },
                new TblCity { CityID = 37, CityName = "Bharatpur", StateID = 21 },
                new TblCity { CityID = 38, CityName = "Sikar", StateID = 21 },
                new TblCity { CityID = 39, CityName = "Pali", StateID = 21 },
                new TblCity { CityID = 40, CityName = "Chittorgarh", StateID = 21 },
                new TblCity { CityID = 41, CityName = "Bhilwara", StateID = 21 },
                new TblCity { CityID = 42, CityName = "Barmer", StateID = 21 },
                new TblCity { CityID = 43, CityName = "Jaisalmer", StateID = 21 },
                new TblCity { CityID = 44, CityName = "Nagaur", StateID = 21 },

                new TblCity { CityID = 45, CityName = "Thiruvananthapuram", StateID = 12 },
                new TblCity { CityID = 46, CityName = "Kochi", StateID = 12 },
                new TblCity { CityID = 47, CityName = "Kozhikode", StateID = 12 },
                new TblCity { CityID = 48, CityName = "Thrissur", StateID = 12 },
                new TblCity { CityID = 49, CityName = "Kollam", StateID = 12 },
                new TblCity { CityID = 50, CityName = "Alappuzha", StateID = 12 },
                new TblCity { CityID = 51, CityName = "Palakkad", StateID = 12 },
                new TblCity { CityID = 52, CityName = "Malappuram", StateID = 12 },
                new TblCity { CityID = 53, CityName = "Kannur", StateID = 12 },
                new TblCity { CityID = 54, CityName = "Kasaragod", StateID = 12 },
                new TblCity { CityID = 55, CityName = "Kottayam", StateID = 12 },
                new TblCity { CityID = 56, CityName = "Pathanamthitta", StateID = 12 },
                new TblCity { CityID = 57, CityName = "Idukki", StateID = 12 },
                new TblCity { CityID = 58, CityName = "Wayanad", StateID = 12 },

                new TblCity { CityID = 59, CityName = "Lucknow", StateID = 26 },
                new TblCity { CityID = 60, CityName = "Kanpur", StateID = 26 },
                new TblCity { CityID = 61, CityName = "Noida", StateID = 26 },
                new TblCity { CityID = 62, CityName = "Greater Noida", StateID = 26 },
                new TblCity { CityID = 63, CityName = "Ghaziabad", StateID = 26 },
                new TblCity { CityID = 64, CityName = "Agra", StateID = 26 },
                new TblCity { CityID = 65, CityName = "Mathura", StateID = 26 },
                new TblCity { CityID = 66, CityName = "Meerut", StateID = 26 },
                new TblCity { CityID = 67, CityName = "Aligarh", StateID = 26 },
                new TblCity { CityID = 68, CityName = "Bareilly", StateID = 26 },
                new TblCity { CityID = 69, CityName = "Moradabad", StateID = 26 },
                new TblCity { CityID = 70, CityName = "Saharanpur", StateID = 26 },
                new TblCity { CityID = 71, CityName = "Prayagraj", StateID = 26 },
                new TblCity { CityID = 72, CityName = "Varanasi", StateID = 26 },
                new TblCity { CityID = 73, CityName = "Gorakhpur", StateID = 26 },
                new TblCity { CityID = 74, CityName = "Jhansi", StateID = 26 },
                new TblCity { CityID = 75, CityName = "Ayodhya", StateID = 26 },

                new TblCity { CityID = 76, CityName = "Bhopal", StateID = 13 },
                new TblCity { CityID = 77, CityName = "Indore", StateID = 13 },
                new TblCity { CityID = 78, CityName = "Gwalior", StateID = 13 },
                new TblCity { CityID = 79, CityName = "Jabalpur", StateID = 13 },
                new TblCity { CityID = 80, CityName = "Ujjain", StateID = 13 },
                new TblCity { CityID = 81, CityName = "Sagar", StateID = 13 },
                new TblCity { CityID = 82, CityName = "Rewa", StateID = 13 },
                new TblCity { CityID = 83, CityName = "Satna", StateID = 13 },
                new TblCity { CityID = 84, CityName = "Dewas", StateID = 13 },
                new TblCity { CityID = 85, CityName = "Ratlam", StateID = 13 },
                new TblCity { CityID = 86, CityName = "Katni", StateID = 13 },
                new TblCity { CityID = 87, CityName = "Chhindwara", StateID = 13 },
                new TblCity { CityID = 88, CityName = "Morena", StateID = 13 },
                new TblCity { CityID = 89, CityName = "Bhind", StateID = 13 },
                new TblCity { CityID = 90, CityName = "Vidisha", StateID = 13 },
           
                // Add Karnataka cities
                new TblCity { CityID = 91, CityName = "Bengaluru", StateID = 11 },
                new TblCity { CityID = 92, CityName = "Mysuru", StateID = 11 },
                new TblCity { CityID = 93, CityName = "Mangalore", StateID = 11 },
                new TblCity { CityID = 94, CityName = "Hubli", StateID = 11 },
                new TblCity { CityID = 95, CityName = "Belagavi", StateID = 11 },
                new TblCity { CityID = 96, CityName = "Davangere", StateID = 11 },
                new TblCity { CityID = 97, CityName = "Ballari", StateID = 11 },
                new TblCity { CityID = 98, CityName = "Gulbarga", StateID = 11 },
                new TblCity { CityID = 99, CityName = "Shimoga", StateID = 11 },
                new TblCity { CityID = 100, CityName = "Tumakuru", StateID = 11 },

                // Add Tamil Nadu cities
                new TblCity { CityID = 101, CityName = "Chennai", StateID = 23 },
                new TblCity { CityID = 102, CityName = "Coimbatore", StateID = 23 },
                new TblCity { CityID = 103, CityName = "Madurai", StateID = 23 },
                new TblCity { CityID = 104, CityName = "Tiruchirappalli", StateID = 23 },
                new TblCity { CityID = 105, CityName = "Salem", StateID = 23 },
                new TblCity { CityID = 106, CityName = "Erode", StateID = 23 },
                new TblCity { CityID = 107, CityName = "Vellore", StateID = 23 },

                // Add Bihar cities
                new TblCity { CityID = 108, CityName = "Patna", StateID = 4 },
                new TblCity { CityID = 109, CityName = "Gaya", StateID = 4 },
                new TblCity { CityID = 110, CityName = "Bhagalpur", StateID = 4 },
                new TblCity { CityID = 111, CityName = "Muzaffarpur", StateID = 4 },
                new TblCity { CityID = 112, CityName = "Purnia", StateID = 4 },
                new TblCity { CityID = 113, CityName = "Darbhanga", StateID = 4 },
                new TblCity { CityID = 114, CityName = "Munger", StateID = 4 },
                new TblCity { CityID = 115, CityName = "Saharsa", StateID = 4 },
                new TblCity { CityID = 116, CityName = "Begusarai", StateID = 4 },

                // Add Chhattisgarh cities
                new TblCity { CityID = 117, CityName = "Raipur", StateID = 5 },
                new TblCity { CityID = 118, CityName = "Bhilai", StateID = 5 },
                new TblCity { CityID = 119, CityName = "Durg", StateID = 5 },
                new TblCity { CityID = 120, CityName = "Korba", StateID = 5 },
                new TblCity { CityID = 121, CityName = "Bilaspur", StateID = 5 },

                //Add West Bengal cities
                new TblCity { CityID = 122, CityName = "Kolkata", StateID = 28 },
                new TblCity { CityID = 123, CityName = "Howrah", StateID = 28 },
                new TblCity { CityID = 124, CityName = "Durgapur", StateID = 28 },
                new TblCity { CityID = 125, CityName = "Siliguri", StateID = 28 },
                new TblCity { CityID = 126, CityName = "Asansol", StateID = 28 },
                new TblCity { CityID = 127, CityName = "Bardhaman", StateID = 28 }

            );
        }

    }
}
