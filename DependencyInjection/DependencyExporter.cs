using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DependencyInjection
{
    using IDependencyReceiver = Action<Type, Func<object>>;
    using ITypeDependencyReceiver = Action<Type, Type>;

    public abstract class DependencyExporter
    {
        private readonly Dictionary<Type, Func<object>> _dependencies;
        private readonly Dictionary<Type, Type> _typeDependencies;
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        protected DependencyExporter()
        {
            _dependencies = new Dictionary<Type,Func<object>>();
            _typeDependencies = new Dictionary<Type, Type>();
            RegisterAllExportedDependencies();
            ConstructHiddenDependencies();
        }
        
        public T Get<T>() where T : class
        {
            return _dependencies[typeof(T)]() as T;
        }
        
        public void ExportDependencies(IDependencyReceiver dependencyReceiver)
        {
            foreach(var (type, provider) in _dependencies)
            {
                dependencyReceiver(type, provider);
            }
        }

        public void ExportTypeDependencies(ITypeDependencyReceiver dependencyReceiver)
        {
            foreach (var (type, typeDependency) in _typeDependencies)
            {
                dependencyReceiver(type, typeDependency);
            }
        }

        protected void RegisterExportedDependency<T>(Func<object> provider)
        {
            _dependencies.Add(typeof(T), provider);
        }

        protected void RegisterExportedDependency<TInterface, TDependency>()
        {
            _typeDependencies.Add(typeof(TInterface), typeof(TDependency));
        }

        protected abstract void ConstructHiddenDependencies();
        protected abstract void RegisterAllExportedDependencies();
    }
}