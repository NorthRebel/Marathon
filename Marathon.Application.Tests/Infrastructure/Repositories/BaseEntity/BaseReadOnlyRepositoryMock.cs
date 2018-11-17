using Moq;
using System;
using System.Linq;
using System.Threading;
using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity
{
    /// <summary>
    /// Mock implementation for <see cref="IReadOnlyRepository{TEntity}"/>
    /// where <typeparamref name="TEntity"/> is <see cref="IBaseEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Entity of repository which not contains default identity key</typeparam>
    public class BaseReadOnlyRepositoryMock<TEntity> : Mock<IReadOnlyRepository<TEntity>>, IBaseRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>
        where TEntity : IBaseEntity
    {
        public List<TEntity> Items { get; set; }

        public BaseReadOnlyRepositoryMock()
        {
            Items = new List<TEntity>();
            ((IBaseRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>)this).SetupMethods();
        }

        void IBaseRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>.SetupMethods()
        {
            GetListOfItems();
            GetSingleItem();
        }

        #region Methods to setup

        private void GetListOfItems()
        {
            Setup(r => r.GetAsync(It.IsAny<Func<IQueryable<TEntity>, TEntity>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Func<IQueryable<TEntity>, TEntity> items, CancellationToken token) =>
                    items.Invoke(Items.AsQueryable()));
        }

        private void GetSingleItem()
        {
            Setup(r => r.GetAsync(It.IsAny<Func<IQueryable<TEntity>, IQueryable<TEntity>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Func<IQueryable<TEntity>, IQueryable<TEntity>> items, CancellationToken token) =>
                    items.Invoke(Items.AsQueryable()));
        }

        #endregion
    }
}
