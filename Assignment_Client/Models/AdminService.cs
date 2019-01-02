using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_Client.AdminServiceReference;
using Assignment_Client.Common;
using Assignment_Client.UserServiceReference;

namespace Assignment_Client.Models
{
    public class AdminService
    {
        AdminServiceClient adminServiceClient = new AdminServiceClient();
        ClientServiceClient clientServiceClient = new ClientServiceClient();
        
        public List<Image> GetAllImage(int id)
        {
            var list = adminServiceClient.GetImageListById(id).ToList();
            var result = new List<Image>();
            list.ForEach(i => result.Add(new Image
            {
                Image1 = i.Image1
            }));
            return result;
        }
        public List<AdminServiceReference.Place> GetPlace()
        {
            var list = adminServiceClient.GetPlaceList().ToList();
            var result = new List<AdminServiceReference.Place>();
            list.ForEach(p => result.Add(new AdminServiceReference.Place
            {
                Id = p.Id,
                Name = p.Name,
                Avatar = p.Avatar,
                Description = p.Description,
                Information = p.Information
            }));
            return result;
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
        public List<Comment> GetCommentList(int id)
        {
            var list = clientServiceClient.GetCommentListById(id).ToList();
            var result = new List<Comment>();
            list.ForEach(cm => result.Add(new Comment
            {
                Comment1 = cm.Comment1
            }));
            return result;
        }
        public bool AddComment(Comment newComment)
        {
            
                var comment = new UserServiceReference.Comment()
                {
                    Comment1 = newComment.Comment1,
                    PlaceId = newComment.PlaceId
                };
                return clientServiceClient.AddComment(comment);
           
        }
        public bool Login(LoginModel loginModel)
        {
            var login = new UserServiceReference.User()
            {
                Email = loginModel.Email,
                Password = loginModel.Password
            };
            var query = clientServiceClient.LoginClient(login);
            if (query)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public UserLogin GetByEmail(string email)
        {
            var query = clientServiceClient.GetByEmail(email);
            if (query != null)
            {
                var userSession = new UserLogin();
                userSession.UserID = query.Id;
                userSession.Email = query.Email;
                return userSession;
            }
            else
            {
                return null;
            }
        }
    }
}