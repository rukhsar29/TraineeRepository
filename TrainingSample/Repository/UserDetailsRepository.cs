using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using TrainingSample.Entities;
using TrainingSample.EntityFramework;

namespace TrainingSample.Repository
{
    public class UserDetailsRepository:IUserDetails
    {
        public void GetEditDetail(UserDetails insert)
        {
            //using(var dbContext=new TraineeEntities)
            //{
            //    var viewModel = dbContext.UserDetails.Where(x => x.UserId == id).FirstOrDefault();
            //    var viewModel1 = us.CarDetails.Where(x => x.UserId == id).ToList();

            //    viewModel.FullName = insert.FullName;
            //    viewModel.UserEmail = insert.UserEmail;
            //    viewModel.PasswordHash = insert.PasswordHash;
            //    viewModel.CivilIdNumber = insert.CivilIdNumber;

            //    viewModel.DOB = insert.DOB;

            //    viewModel.MobileNo = insert.MobileNo;
            //    viewModel.Address = insert.Address;
            //    //viewModel.RoleId = insert.RoleId;
            //    viewModel.ProfilePic = insert.ProfilePic;


            //    viewModel.CreatedDate = insert.CreatedDate;
            //    viewModel.ModifiedDate = insert.ModifiedDate;
            //    viewModel.IsNotificationActive = insert.IsNotificationActive;
            //    viewModel.IsActive = insert.IsActive;
            //    viewModel.DeviceId = insert.DeviceId;
            //    viewModel.DeviceType = insert.DeviceType;
            //    viewModel.FcmToken = insert.FcmToken;
            //    viewModel.verify = insert.verify;
            //    viewModel.VerifiedBy = insert.VerifiedBy;
            //    viewModel.Area = insert.Area;
            //    viewModel.Block = insert.Block;
            //    viewModel.Street = insert.Street;
            //    viewModel.Housing = insert.Housing;
            //    viewModel.Floor = insert.Floor;
            //    viewModel.NewPass = insert.NewPass;
            //    viewModel.ConPass = insert.ConPass;
            //    viewModel.Jadda = insert.Jadda;
            //    viewModel.Reason = insert.Reason;
            //    viewModel.ActivatedBy = insert.ActivatedBy;
            //    viewModel.ActivatedDate = insert.ActivatedDate;

            //    // viewModel1.CarLicense = insert.CarLicense;
            //    var cars = us.CarDetails.Where(x => x.UserId == id)
            //         .Select(y => new carDetailsForUser { CarLicense = y.CarLicense, Id = y.Id }).ToList();
            //    //db.Employees.Add(emp);
            //    //db.Departments.Add(dep);
            //    us.Entry(viewModel).State = EntityState.Modified;
            //    us.Entry(cars).State = EntityState.Modified;


            //    us.SaveChanges();
            //}
           
        }

        public void GetInsertDetail(UserDetails insert)
        {
            using (var dbContext = new TraineeEntities())
            {
                

                //string FileName = Path.GetFileNameWithoutExtension(insert.ImageFile.FileName);


                //string FileExtension = Path.GetExtension(insert.ImageFile.FileName);


                //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;


                //string UploadPath = ConfigurationManager.AppSettings["UserProfilePic"].ToString();


                //insert.ProfilePic = UploadPath + FileName;
                ////insert.ProfilePic = FileName;


                //insert.ImageFile.SaveAs(insert.ProfilePic);



                var user = new UserDetail()
                {
                    FullName = insert.FullName,
                    UserEmail = insert.UserEmail,
                    PasswordHash = insert.PasswordHash,
                    CivilIdNumber = insert.CivilIdNumber,

                    DOB = insert.DOB,
                    MobileNo = insert.MobileNo,
                    Address = insert.Address,
                    //RoleId = insert.RoleId,

                    ProfilePic = insert.ProfilePic,



                    CreatedDate = insert.CreatedDate,
                    ModifiedDate = insert.ModifiedDate,
                    IsNotificationActive = insert.IsNotificationActive,
                    IsActive = insert.IsActive,
                    DeviceId = insert.DeviceId,
                    DeviceType = insert.DeviceType,
                    FcmToken = insert.FcmToken,
                    verify = insert.verify,
                    VerifiedBy = insert.VerifiedBy,
                    Area = insert.Area,
                    Block = insert.Block,
                    Street = insert.Street,
                    Housing = insert.Housing,
                    Floor = insert.Floor,
                    NewPass = insert.NewPass,
                    ConPass = insert.ConPass,
                    Jadda = insert.Jadda,
                    Reason = insert.Reason,
                    ActivatedBy = insert.ActivatedBy,
                    ActivatedDate = insert.ActivatedDate


                };

                var car = new CarDetail()
                {
                    CarLicense = insert.CarLicense,
                    UserId = insert.UserId

                };
                dbContext.UserDetails.Add(user);
                dbContext.CarDetails.Add(car);
                dbContext.SaveChanges();
            }
        }

       

        public IEnumerable<UserDetails> GetUserDetails()
        {
            using (var dbContext=new TraineeEntities())
            {
                List<UserDetail> userDetails = dbContext.UserDetails.ToList();
                List<CarDetail> carDetails = dbContext.CarDetails.ToList();
                List<UserDetails> userViewModels = new List<UserDetails>();
                foreach (var user in userDetails)
                {

                    var data = new UserDetails
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        CivilIdNumber = user.CivilIdNumber,


                    };

                    var cardetails = string.Join(",", carDetails.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    userViewModels.Add(data);
                    
                }

                return userViewModels;


                

            }
           


        }
    }
}