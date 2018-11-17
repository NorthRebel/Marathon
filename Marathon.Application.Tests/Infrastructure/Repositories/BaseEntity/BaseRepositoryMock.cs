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
    /// Mock implementation for <see cref="IRepository{TEntity}"/>
    /// where <typeparamref name="TEntity"/> is <see cref="IBaseEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Entity of repository which not contains default identity key</typeparam>
    public abstract class BaseRepositoryMock<TEntity> : Mock<IRepository<TEntity>>, IBaseRepositoryMock<IRepository<TEntity>, TEntity> 
        where TEntity : IBaseEntity
    {
        private bool _hasPendingChanges;

        public List<TEntity> Items { get; set; }

        protected BaseRepositoryMock()
        {
            Items = new List<TEntity>();
            ((IBaseRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>)this).SetupMethods();
        }

        void IBaseRepositoryMock<IRepository<TEntity>, TEntity>.SetupMethods()
        {
            GetListOfItems();
            GetSingleItem();
            AddItem();
            RemoveItem();
            UpdateItem();
            HasPendingChanges();

            // TODO: Implement other IRepository members
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

        protected abstract void AddItem();

        protected abstract void RemoveItem();

        protected abstract void UpdateItem();

        private void HasPendingChanges()
        {
            SetupGet(r => r.HasPendingChanges).Returns(() =>
            {
                if (_hasPendingChanges)
                    return true;

                _hasPendingChanges = true;
                return Items.Any();
            });
        }

        #endregion
    }
}
