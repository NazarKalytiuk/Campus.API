using Domain.Infrastruscture.Contracts;
using Domain.Models;
using Services.Contracts;
using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RequestModels;
using Microsoft.AspNet.Identity;

namespace Services.Implementation
{
    [UsedImplicitly]
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Task ChangePasswordAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> CreateAsync(RegisterUserRequestModel model)
        {
            ApplicationUser user = new ApplicationUser() { Email = model.Email, UserName = model.Email };
            IdentityResult result = await _unitOfWork.UserManager.CreateAsync(user, model.Password);
            //TODO check result
            return user;
        }

        public Task RemoveAsync()
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync()
        {
            throw new NotImplementedException();
        }
    }
}

