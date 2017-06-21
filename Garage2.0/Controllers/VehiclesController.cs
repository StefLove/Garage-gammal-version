﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.DataAccess;
using Garage2._0.Models;

namespace Garage2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index(string searchNumberPlate = "", string typeOfVehicle = "", string orderBy = "")
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);

            ViewBag.Fordon = "fordon";
            ViewBag.TypeOfVehicle = typeOfVehicle;

            if (typeOfVehicle != "")
            {
                switch (typeOfVehicle.ToUpper())
                {
                    case "CAR":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Car); ViewBag.Fordon = "bilar"; ViewBag.TypeOfVehicle = "Car"; break;
                    case "BUS":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Bus); ViewBag.Fordon = "bussar"; ViewBag.TypeOfVehicle = "Bus"; break;
                    case "BOAT":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Boat); ViewBag.Fordon = "båtar"; ViewBag.TypeOfVehicle = "Boat"; break;
                    case "AIRPLANE":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Airplane); ViewBag.Fordon = "flygplan"; ViewBag.TypeOfVehicle = "Airplane"; break;
                    case "MOTORCYCLE":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Motorcycle); ViewBag.Fordon = "motorcyklar"; ViewBag.TypeOfVehicle = "Motorcycle"; break;
                }
                if (vehicles.Count() == 0) return HttpNotFound();
            }

            if (orderBy != "")
                switch (orderBy.ToUpper())
                {
                    case "TYPEOFVEHICLE": vehicles = vehicles.OrderBy(v => v.VehicleType); break;
                    case "REGNUMBER": vehicles = vehicles.OrderBy(v => v.RegNumber); break;
                    case "COLOR": vehicles = vehicles.OrderBy(v => v.Color); break;
                    case "NOOFWHEELS": vehicles = vehicles.OrderBy(v => v.NoOfWheels); break;
                    case "BRAND": vehicles = vehicles.OrderBy(v => v.Brand); break;
                    case "MODEL": vehicles = vehicles.OrderBy(v => v.Model); break;
                }

            if (!String.IsNullOrEmpty(searchNumberPlate))
            {
                vehicles = vehicles.Where(p => p.RegNumber.StartsWith(searchNumberPlate));
            }

            List<VehicleBase> vehicleBaseList = new List<VehicleBase>();

            foreach (var item in vehicles)
            {
                var vehicleBase = new VehicleBase();
                vehicleBase.MemberName = item.Member.Name;
                vehicleBase.VehicleType = item.VehicleType.TypeOfVehicle.ToString();
                vehicleBase.RegNumber = item.RegNumber;
                vehicleBase.CheckInTime = item.CheckInTime;
                vehicleBaseList.Add(vehicleBase);
            }

            ViewBag.NoOfParkedVehicles = vehicles.Count();

            return View(vehicleBaseList);
        }


        // GET: Vehicles
        public ActionResult DetailedIndex(string searchNumberPlate = "", string typeOfVehicle = "", string orderBy = "")
        {
            var vehicles = db.Vehicles.Include(v => v.Member).Include(v => v.VehicleType);

            ViewBag.Fordon = "fordon";
            ViewBag.TypeOfVehicle = typeOfVehicle;

            if (typeOfVehicle != "")
            {
                switch (typeOfVehicle.ToUpper())
                {
                    case "CAR":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Car); ViewBag.Fordon = "bilar"; ViewBag.TypeOfVehicle = "Car"; break;
                    case "BUS":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Bus); ViewBag.Fordon = "bussar"; ViewBag.TypeOfVehicle = "Bus"; break;
                    case "BOAT":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Boat); ViewBag.Fordon = "båtar"; ViewBag.TypeOfVehicle = "Boat"; break;
                    case "AIRPLANE":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Airplane); ViewBag.Fordon = "flygplan"; ViewBag.TypeOfVehicle = "Airplane"; break;
                    case "MOTORCYCLE":
                        vehicles = vehicles.Where(v => v.VehicleType.TypeOfVehicle == TypeOfVehicle.Motorcycle); ViewBag.Fordon = "motorcyklar"; ViewBag.TypeOfVehicle = "Motorcycle"; break;
                }
                if (vehicles.Count() == 0) return HttpNotFound();
            }

            if (orderBy != "")
                switch (orderBy.ToUpper())
                {
                    case "TYPEOFVEHICLE": vehicles = vehicles.OrderBy(v => v.VehicleType); break;
                    case "REGNUMBER": vehicles = vehicles.OrderBy(v => v.RegNumber); break;
                    case "COLOR": vehicles = vehicles.OrderBy(v => v.Color); break;
                    case "NOOFWHEELS": vehicles = vehicles.OrderBy(v => v.NoOfWheels); break;
                    case "BRAND": vehicles = vehicles.OrderBy(v => v.Brand); break;
                    case "MODEL": vehicles = vehicles.OrderBy(v => v.Model); break;
                }

            if (!String.IsNullOrEmpty(searchNumberPlate))
            {
                vehicles = vehicles.Where(p => p.RegNumber.StartsWith(searchNumberPlate));
            }

            ViewBag.NoOfParkedVehicles = vehicles.Count();

            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNumber,Color,NoOfWheels,Brand,Model,CheckInTime,MemberId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Park
        public ActionResult Park(string typeOfVehicle)
        {

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id");

            ViewBag.TypeOfVehicle = typeOfVehicle;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Park([Bind(Include = "Id,TypeOfVehicle,RegNumber,Color,NoOfWheels,Brand,Model")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id", vehicle.VehicleTypeId);

            return View(vehicle);
        }


        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Color,NoOfWheels,Brand,Model,CheckInTime,MemberId,VehicleTypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", vehicle.MemberId);
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Id", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

//namespace Garage2._0.Controllers
//{
//    public class ParkedVehiclesController : Controller
//    {
//        private GarageContext db = new GarageContext();

//        // GET: ParkedVehicles/Index
//        public ActionResult Index(string searchNumberPlate = "", string typeOfVehicle = "", string orderBy = "")
//        {
//            var vehicles = db.ParkedVehicles.Select(v => v);

//            ViewBag.Fordon = "fordon";
//            ViewBag.TypeOfVehicle = typeOfVehicle;

//            if (typeOfVehicle != "")
//            {
//                switch (typeOfVehicle.ToUpper())
//                {
//                    case "CAR":
//                        vehicles = vehicles.Where(v => v.TypeOfVehicle == Car); ViewBag.Fordon = "bilar"; ViewBag.TypeOfVehicle = "Car"; break;
//                    case "BUS":
//                        vehicles = vehicles.Where(v => v.TypeOfVehicle == Bus); ViewBag.Fordon = "bussar"; ViewBag.TypeOfVehicle = "Bus"; break;
//                    case "BOAT":
//                        vehicles = vehicles.Where(v => v.TypeOfVehicle == Boat); ViewBag.Fordon = "båtar"; ViewBag.TypeOfVehicle = "Boat"; break;
//                    case "AIRPLANE":
//                        vehicles = vehicles.Where(v => v.TypeOfVehicle == Airplane); ViewBag.Fordon = "flygplan"; ViewBag.TypeOfVehicle = "Airplane"; break;
//                    case "MOTORCYCLE":
//                        vehicles = vehicles.Where(v => v.TypeOfVehicle == Motorcycle); ViewBag.Fordon = "motorcyklar"; ViewBag.TypeOfVehicle = "Motorcycle"; break;
//                }
//                if (vehicles.Count() == 0) return HttpNotFound();
//            }

//            if (orderBy != "")
//                switch (orderBy.ToUpper())
//                {
//                    case "TYPEOFVEHICLE": vehicles = vehicles.OrderBy(v => v.TypeOfVehicle); break;
//                    case "REGNUMBER": vehicles = vehicles.OrderBy(v => v.RegNumber); break;
//                    case "COLOR": vehicles = vehicles.OrderBy(v => v.Color); break;
//                    case "NOOFWHEELS": vehicles = vehicles.OrderBy(v => v.NoOfWheels); break;
//                    case "BRAND": vehicles = vehicles.OrderBy(v => v.Brand); break;
//                    case "MODEL": vehicles = vehicles.OrderBy(v => v.Model); break;
//                }

//            if (!String.IsNullOrEmpty(searchNumberPlate))
//            {
//                vehicles = vehicles.Where(p => p.RegNumber.StartsWith(searchNumberPlate));
//            }

//            ViewBag.NoOfParkedVehicles = vehicles.Count();

//            return View(vehicles.ToList());
//        }

//        // GET: ParkedVehicles/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
//            if (parkedVehicle == null)
//            {
//                return HttpNotFound();
//            }
//            return View(parkedVehicle);
//        }

//        // GET: ParkedVehicles/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ParkedVehicles/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,TypeOfVehicle,RegNumber,Color,NoOfWheels,Brand,Model,CheckInTime,CheckOutTime,ParkingDuration,ParkingFee")] ParkedVehicle parkedVehicle)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ParkedVehicles.Add(parkedVehicle);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(parkedVehicle);
//        }

//        // GET: ParkedVehicles/Park
//        public ActionResult Park(string typeOfVehicle)
//        {
//            ViewBag.TypeOfVehicle = typeOfVehicle;

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Park([Bind(Include = "Id,TypeOfVehicle,RegNumber,Color,NoOfWheels,Brand,Model")] ParkedVehicle parkedVehicle)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ParkedVehicles.Add(parkedVehicle);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(parkedVehicle);
//        }

//        // GET: ParkedVehicles/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
//            if (parkedVehicle == null)
//            {
//                return HttpNotFound();
//            }
//            return View(parkedVehicle);
//        }

//        // POST: ParkedVehicles/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,TypeOfVehicle,RegNumber,Color,NoOfWheels,Brand,Model,CheckInTime,CheckOutTime,ParkingDuration,ParkingFee")] ParkedVehicle parkedVehicle)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(parkedVehicle).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(parkedVehicle);
//        }

//        // GET: ParkedVehicles/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
//            if (parkedVehicle == null)
//            {
//                return HttpNotFound();
//            }
//            return View(parkedVehicle);
//        }

//        // POST: ParkedVehicles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
//            var checkOutTime = DateTime.Now;
//            TimeSpan parkingDuration = checkOutTime - parkedVehicle.CheckInTime;
//            ViewBag.CheckOutTime = checkOutTime;

//            ViewBag.ParkingFee = Fee(parkingDuration);
//            string pDuration;
//            if (parkingDuration.Days > 0)
//            {
//                pDuration = $"{parkingDuration:dd} dygn {parkingDuration:hh\\:mm\\:ss} (tt:mm:ss)";
//            }
//            else pDuration = $"{parkingDuration:hh\\:mm\\:ss} (tt:mm:ss)";
//            ViewBag.ParkingDuration = pDuration;

//            db.ParkedVehicles.Remove(parkedVehicle);
//            db.SaveChanges();
//            return View("Receipt", parkedVehicle);
//        }

//        private decimal Fee(TimeSpan parkingDuration)
//        {
//            if ((parkingDuration.Minutes % 10) > 0 || ((parkingDuration.Minutes % 10 == 0) && (parkingDuration.Seconds > 0)))
//            {
//                return 10 * ((parkingDuration.Days * 144) + (parkingDuration.Hours * 6) + (parkingDuration.Minutes / 10) + 1);
//            }
//            return 10 * ((parkingDuration.Days * 144) + (parkingDuration.Hours * 6) + (parkingDuration.Minutes / 10));
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
