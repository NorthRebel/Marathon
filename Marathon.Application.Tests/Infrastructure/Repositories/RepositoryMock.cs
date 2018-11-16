using Moq;
using System;
using System.Linq;
using System.Threading;
using Marathon.Domain.Common;
using System.Collections.Generic;
using Marathon.Application.Repositories;

namespace Marathon.Application.Tests.Infrastructure.Repositories
{
    /// <summary>
    /// Mock implementation for <see cref="IRepository{TEntity}"/>
    /// </summary>
    /// <typeparam name="TEntity">Entity of repository</typeparam>
    public class RepositoryMock<TEntity> : Mock<IRepository<TEntity>>, IRepositoryMock<IRepository<TEntity>, TEntity>
        where TEntity : IEntity
    {
        private bool _hasPendingChanges;

        public List<TEntity> Items { get; set; }

        public RepositoryMock()
        {
            Items = new List<TEntity>();
            ((IRepositoryMock<IReadOnlyRepository<TEntity>, TEntity>)this).SetupMethods();
        }

        void IRepositoryMock<IRepository<TEntity>, TEntity>.SetupMethods()
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

        private void AddItem()
        {
            Setup(r => r.Add(It.IsAny<TEntity>()))
                .Callback((TEntity newItem) =>
                {
                    newItem.Id = this.Object.HasPendingChanges ? Items.Max(i => i.Id) + 1 : 1;
                    Items.Add(newItem);
                });
        }

        private void RemoveItem()
        {
            Setup(r => r.Remove(It.IsAny<TEntity>()))
                .Callback((TEntity itemToRemove) => Items.Remove(itemToRemove));
        }

        private void UpdateItem()
        {
            Setup(r => r.Update(It.IsAny<TEntity>())).Callback((TEntity itemToUpdate) =>
            {
                var foundItem = Items.Find(i => i.Id == itemToUpdate.Id);
                this.Object.Remove(foundItem);
                this.Object.Add(foundItem);
            });
        }

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
