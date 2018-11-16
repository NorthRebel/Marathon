using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Marathon.Application.Repositories;
using Marathon.Domain.Common;
using Moq;

namespace Marathon.Application.Tests.Infrastructure.Repositories
{
    public class ReadOnlyRepositoryMock<TEntity> : Mock<IReadOnlyRepository<TEntity>>, IRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>
        where TEntity : IEntity
    {
        public List<TEntity> Items { get; set; }

        public ReadOnlyRepositoryMock()
        {
            Items = new List<TEntity>();
            ((IRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>)this).SetupMethods();
        }

        void IRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>.SetupMethods()
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
