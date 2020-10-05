using System;
using System.Collections.Generic;
using System.Linq;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.BLL
{
    public class PackageManager
    {
        public static List<Packages> GetAll()
        {
            var context = new TravelExperts_Group3Context();
            var packages = context.Packages.ToList();
            return packages;

        }
        public static Packages GetPackagesById(int id)
        {
            var context = new TravelExperts_Group3Context();
            var package = context.Packages.Find(id);
            return package;
        }
    }
}
