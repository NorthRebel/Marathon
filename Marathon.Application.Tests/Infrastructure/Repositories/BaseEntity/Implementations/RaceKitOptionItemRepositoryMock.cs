using Moq;
using Marathon.Domain.Entities;

namespace Marathon.Application.Tests.Infrastructure.Repositories.BaseEntity.Implementations
{
    /// <summary>
    /// Mock implementation for <see cref="RaceKitOptionItem"/>
    /// </summary>
    public class RaceKitOptionItemRepositoryMock : BaseRepositoryMock<RaceKitOptionItem>
    {
        protected override void AddItem()
        {
            Setup(r => r.Add(It.IsAny<RaceKitOptionItem>()))
                .Callback((RaceKitOptionItem newItem) =>
                {
                    Items.Add(newItem);
                });
        }

        protected override void RemoveItem()
        {
            Setup(r => r.Remove(It.IsAny<RaceKitOptionItem>()))
               .Callback((RaceKitOptionItem itemToRemove) => Items.Remove(Items.Find(
                    ki => ki.ItemId == itemToRemove.ItemId && ki.OptionId == itemToRemove.OptionId)));
        }

        protected override void UpdateItem()
        {
            Setup(r => r.Remove(It.IsAny<RaceKitOptionItem>())).Callback((RaceKitOptionItem itemToUpdate) =>
            {
                var foundItem = Items.Find(ki => ki.ItemId == itemToUpdate.ItemId && ki.OptionId == itemToUpdate.OptionId);
                this.Object.Remove(foundItem);
                this.Object.Add(foundItem);
            });
        }
    }
}
