Paket will then ask for username and password.

This credentials will be used if no username and password for the source are configured in the [`paket.dependencies` file](nuget-dependencies.html).

The configuration file can be found in:

	let AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
	let PaketConfigFolder = Path.Combine(AppDataFolder, "Paket")
	let PaketConfigFile = Path.Combine(PaketConfigFolder, "paket.config")