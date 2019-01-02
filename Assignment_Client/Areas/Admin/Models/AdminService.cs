using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_Client.AdminServiceReference;

namespace Assignment_Client.Areas.Admin.Models
{
    public class AdminService
    {
        AdminServiceClient adminServiceClient = new AdminServiceClient();
        public bool Login(LoginModel loginModel)
        {
            var result = new AdminServiceReference.Admin()
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };
            var query = adminServiceClient.LoginAdmin(result);
            if (query)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public List<Place> GetAllPlace()
        {
            var list = adminServiceClient.GetPlaceList().ToList();
            var result = new List<Place>();
            list.ForEach(b => result.Add(new Place()
            {
                Id = b.Id,
                CategoryId = Convert.ToString(b.CategoryPlaceId),
                Name = b.Name,
                Description = b.Description,
                Information = b.Information
            }));
            return result;
        }
        public bool AddPlace(Place newPlace)
        {
            var place = new AdminServiceReference.Place()
            {
                Id = newPlace.Id,
                CategoryPlaceId = Convert.ToInt32(newPlace.CategoryId),
                Name = newPlace.Name,
                Description = newPlace.Description,
                Information = newPlace.Information,
                Status = newPlace.Status
            };
            return adminServiceClient.AddPlace(place);
        }

        public Place Find(int id)
        {
            var find = adminServiceClient.GetPlaceById(id);
            Place place = new Place();

            place.Id = find.Id;
            place.Name = find.Name;
            place.Information = find.Information;
            place.Description = find.Description;
            return place;
        }
        public bool EditPlace(Place newPlace)
        {
            var place = new AdminServiceReference.Place()
            {
                Id = newPlace.Id,
                Name = newPlace.Name,
                Description = newPlace.Description,
                Information = newPlace.Information,
                Status = newPlace.Status
            };
            return adminServiceClient.UpdatePlace(place);
        }
        public bool DeletePlace(int id)
        {
            return adminServiceClient.DeletePlace(id);
        }
    }
}