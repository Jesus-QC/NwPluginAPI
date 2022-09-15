﻿namespace PluginAPI.Core.Factories
{
	using PluginAPI.Core.Interfaces;
	using System.Collections.Generic;

	/// <summary>
	/// Factory for entities.
	/// </summary>
	/// <typeparam name="T">The entity type.</typeparam>
	public class Factory<T> : IEntityFactory<T> where T : IEntity
    {    
        internal Dictionary<IGameComponent, T> Entities = new Dictionary<IGameComponent, T>();

		/// <summary>
		/// Gets all entities stored in factory.
		/// </summary>
		/// <returns>List of all entities.</returns>
        public IEnumerable<T> Get() => Entities.Values;

		/// <summary>
		/// Creates new entity.
		/// </summary>
		/// <param name="component">The game component</param>
		/// <returns>Entity.</returns>
        public virtual T Create(IGameComponent component) => default(T);

		/// <summary>
		/// Gets entity from factory.
		/// </summary>
		/// <param name="component">The game component.</param>
		/// <returns>Entity.</returns>
        public T GetOrAdd(IGameComponent component)
        {
            if (Entities.TryGetValue(component, out T entity))
            {
                return entity;
            }
            else
            {
                var ent = Create(component);
                Entities.Add(component, ent);
                return ent;
            }
        }
    }
}