local roombaspawns = Objects.FindRoombas()
function CommandHandler(args)
	if args[2] == "givehammer" then
		if Console.CheatsActive() then
			Objects.SpawnObject(0, Objects.FindPlayer()[1], Objects.FindPlayer()[2], Objects.FindPlayer()[3])
		end
	elseif args[2] == "roombahell" then
		if Console.CheatsActive() then
			for i=1, 100 / #roombaspawns do
				for i, v in pairs(roombaspawns) do
					Objects.SpawnObject(1, v[1], v[2], v[3])
				end
			end
		end
	end
end