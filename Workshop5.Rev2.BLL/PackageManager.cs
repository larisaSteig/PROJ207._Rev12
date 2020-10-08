using System.Collections.Generic;
using System.Linq;
using Workshop5.Rev2.Data.Domain;

namespace Workshop5.Rev2.BLL
{
    public class PackageManager
    { //@*coded by Larisa Steig*@//
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

        public static void Add(Packages package)
        {
            var context = new TravelExperts_Group3Context();
            context.Packages.Add(package);
            context.SaveChanges();
        }

        public static Packages Find(int id)
        {
            var context = new TravelExperts_Group3Context();
            var trip = context.Packages.Find(id);
            return trip;
        }

        public static void update(Packages package)
        {
            var context = new TravelExperts_Group3Context();
            var originalTrip = context.Packages.Find(package.PackageId);
            originalTrip.PkgName = package.PkgName;
            originalTrip.PkgDesc = package.PkgDesc;
            context.SaveChanges();
        }
    }
}
