function CommandHandler(args)
	if args[2] == "givehammer" then
		if Console.CheatsActive() then
			Objects.SpawnObject(0, Objects.FindPlayer()[1], Objects.FindPlayer()[2], Objects.FindPlayer()[3])
		end
	end
end