using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HomesEngland.Boundary
{
    using IDependencyReceiver = Action<Type, Func<object>>;

    public abstract class DependencyExporter
    {
        private readonly Dictionary<Type, Func<object>> _dependencies;
        
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        protected DependencyExporter()
        {
            _dependencies = new Dictionary<Type,Func<object>>();
            
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

        protected void RegisterExportedDependency<T>(Func<object> provider)
        {
            _dependencies.Add(typeof(T), provider);
        }

        protected abstract void ConstructHiddenDependencies();
        protected abstract void RegisterAllExportedDependencies();
    }
}