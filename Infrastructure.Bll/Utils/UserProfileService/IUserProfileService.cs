using Model.DtoModels;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Bll.Utils.UserProfileService
{
    public interface IUserProfileService
    {
        User ParseUserProfile(PinnedFile file);
    }
}
