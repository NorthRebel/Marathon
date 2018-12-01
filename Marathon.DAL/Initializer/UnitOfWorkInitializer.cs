using System.Threading;
using System.Threading.Tasks;
using Marathon.Domain.Common;
using Marathon.DAL.UnitOfWork;
using Marathon.DAL.Repositories;
using System.Collections.Generic;
using Marathon.Domain.Enumerations;

namespace Marathon.DAL.Initializer
{
    using Gender = Domain.Entities.Gender;
    using SignUpStatus = Domain.Entities.SignUpStatus;
    using UserType = Domain.Entities.UserType;
    using GenderEnum = Domain.Enumerations.Gender;
    using UserTypeEnum = Domain.Enumerations.UserType;
    using SignUpStatusEnum = Domain.Enumerations.SignUpStatus;

    /// <summary>
    /// Initializer for repositories of <see cref="IUnitOfWork"/>
    /// </summary>
    public class UnitOfWorkInitializer : IEnumEntityInitializer
    {
        private readonly IUnitOfWork _uow;
        private readonly CancellationToken _cancellationToken;

        public UnitOfWorkInitializer(IUnitOfWork uow, CancellationToken cancellationToken)
        {
            _uow = uow;
            _cancellationToken = cancellationToken;
        }

        public async Task Seed()
        {
            SeedGenders();
            SeedUserTypes();
            SeedSignUpStatuses();

            await _uow.CommitAsync(_cancellationToken);
        }

        #region Initialize linked enumerations

        public void SeedUserTypes()
        {
            SeedEnumeration<UserType, char, UserTypeEnum>(_uow.UserTypes, UserTypeEnum.GetAll<UserTypeEnum>());
        }

        public void SeedGenders()
        {
            SeedEnumeration<Gender, char, GenderEnum>(_uow.Genders, GenderEnum.GetAll<GenderEnum>());
        }

        public void SeedSignUpStatuses()
        {
            SeedEnumeration<SignUpStatus, byte, SignUpStatusEnum>(_uow.SignUpStatuses, SignUpStatusEnum.GetAll<SignUpStatusEnum>());
        }

        #region Seed Helpers        

        public void SeedEnumeration<TEntity, TKey, TEntityEnum>(IReadOnlyRepository<TEntity> repository, IEnumerable<TEntityEnum> items) 
            where TEntity : IEnumEntity<TKey>, new() where TEntityEnum : Enumeration<TKey, TEntity>
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #endregion
    }
}
