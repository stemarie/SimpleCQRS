namespace SimpleCqrs.MassTransit
{
    public static class ConfigureSimpleCqrs
    {
        public static ConfigSimpleCqrs SimpleCqrs(this global::MassTransit.Configurators.Configurator configure, ISimpleCqrsRuntime runtime)
        {
            var configSimpleCqrs = new ConfigSimpleCqrs(runtime);
            configSimpleCqrs.Configure(configure);
            return configSimpleCqrs;
        }
    }
}