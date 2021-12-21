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
if Scenes.GetCurrentScene() == "LuaMaps" then
	Objects.SpawnObjectExt(2, 0, 0, 0, 0, 0, 0)
	Objects.SpawnObjectExt(2, 4, 0, 0, 0, 0, 0)
	Objects.SpawnObjectExt(3, 8, 0, -2, 0, 0, 0)
	Objects.SetPlayerPos(0, 1, 0)
end