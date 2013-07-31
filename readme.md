# Radiator 2.0

# What is Radiator 2.0?
--------------------
Radiator is a small framework that provides functionlity to execute and validate commands. The point of the framework is to work in conjuction with the CQRS (http://martinfowler.com/bliki/CQRS.html) methodology. This framework does not provide Event Sourcing or Querying. This framework is purely for command execution and validation. This framework was first built to be used with MVC web projects, however it could be used in any kind of project and there is no reference or dependance on MVC.


# How to use it?
--------------------
## Setup

To set up Radiator you need to subscribe your CommandValidators and CommandExecutors to your Commands. Each Command can have zero or one CommandValidator, A Command must have a CommandExecutor.

To subscribe these Validators and Executors, you must provide a implementation of ICommandDependencyResolver, there are 2 methods you need to satisfy:

```C#
     CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command;
     CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command;   
```

### Here is a StructureMap example

```C#

    public class StructureMapDependancyResolver : ICommandDependencyResolver
    {
        public CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command
        {
            return ObjectFactory.TryGetInstance<CommandValidator<TCommand>>();
        }

        public CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command
        {
            return ObjectFactory.TryGetInstance<CommandExecutor<TCommand>>();
        }
    }
	
	
	
	StructureMapDependancyResolver resolver = new StructureMapDependancyResolver();
	
	//Subscribe your CommandValidators and CommandExecutors to your Commands
	
	ObjectFactory.Configure({
		x.For<CommandExecutor<UpdateUserCredentialsCommand>>().Use<UpdateUserCredentialsExecutor>();
		x.For<CommandValidator<UpdateUserCredentialsCommand>>().Use<UpdateUserCredentialsValidator>();
	});
	
	
	//Config the CommandService
	
	CommandServiceConfiguration config = new CommandServiceConfiguration(resolver);
	
	CommandService service = new CommandService(config); //Good to Go!
	
	//example command executing	
	ValidationResult<UpdateUserCredentialsCommand> result = service.Execute(new UpdateUserCredentialsCommand());
	
	/*
	    if(result.HasErrors);
		
        if(result.HasError<UserNotFoundError>()); 
		
        if(result.HasErrorFor<Under18Error>(cmd => cmd.Age);
		
        if(result.HasErrorFor(cmd => cmd.FirstName);      
		
        UserNotFoundError error = result.GetError<UserNotFoundError>();
		
        Under18Error error = result.GetErrorFor<Under18Error>(cmd.Age);       	
	*/
	
	
```


## Command Validators

When a Command is executed, Radiator will initially look for a CommandValidator, if it finds one it will then pass the Command into 
the Validate(..) method of the CommandValidator. If the CommandValidator adds an error to the Command then the executing will stop and return back to the user.

CommandValidators are not mandatory, but its advisable to have one.

### Example Validator

```C#

    public class UpdateUserCredentialsValidator : CommandValidator<UpdateUserCredentialsCommand> 
    {
        public override void ValidateCommand(UpdateUserCredentialsCommand command)
        {
            //Add a general error
            if (command.FirstName != "Michael")
                    AddError(new UserNotFoundError());

            //Add an error to a property
            if(command.Age < 18)
                    AddErrorFor(new Under18Error(), c => c.Age);
        }
    }
    

```

## Command Executors

Its the job of the CommandExecutor to actually execute the purpose of the Command. The Command will only get passed to the CommandExecutor if the validation passed (CommandValidator). CommandExecutors tend to have dependencies they require to execute their job, these dependencies are typically passed in the constructor of the Executor.

An instance of the CommandService is passed to the CommandExecutor, this allows you to execute Commands within CommandExecutors.

### Example Executor

```C#
	public class UpdateUserCredentialsExecutor : CommandExecutor<UpdateUserCredentialsCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateUserCredentialsCommandExecutor(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void ExecuteCommand(ICommandService commandService, UpdateUserCredentialsCommand command)
        {
            _dbContext.Attach(new UserCredentials()
                              {
                                  Id = command.Id,
                                  Name = command.Name,
                                  Age = command.Age
                              });

            _dbContext.SaveChanges();
        }
    }

```


Contact
--------------------
Any suggestions? moans? or questions? 
Twitter: @_MikeRodda 
Mail: fodsuk at hotmail dot com
Git: https://github.com/Fodsuk/Radiator


Enjoy :)
