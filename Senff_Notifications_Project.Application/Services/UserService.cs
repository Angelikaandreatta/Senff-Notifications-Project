using AutoMapper;
using Senff_Notifications_Project.Application.DTOs;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Models;
using Senff_Notifications_Project.Domain.Repositories;

namespace Senff_Notifications_Project.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserModel> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultService<UserDto>> Create(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail<UserDto>("Object must be provided.");

            var userModel = _mapper.Map<UserDto, UserModel>(userDto);
            var createdUser = await _repository.Create(userModel);
            var createdUserDto = _mapper.Map<UserModel, UserDto>(createdUser);

            return ResultService.Ok(createdUserDto);
        }

        public async Task<ResultService<UserDto>> GetById(Guid id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return ResultService.Fail<UserDto>("User not found.");

            var userDto = _mapper.Map<UserModel, UserDto>(user);
            return ResultService.Ok(userDto);
        }

        public async Task<ResultService> Update(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail("Object must be provided.");

            var userModel = _mapper.Map<UserDto, UserModel>(userDto);
            await _repository.Update(userModel);

            return ResultService.Ok("User updated successfully.");
        }

        public async Task<ResultService> Delete(Guid id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return ResultService.Fail("User not found.");

            await _repository.Delete(user);
            return ResultService.Ok("User deleted successfully.");
        }
    }
}
