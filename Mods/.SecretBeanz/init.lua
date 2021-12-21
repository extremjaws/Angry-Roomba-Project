local roombaspawn = Objects.FindRoombas()[1]
local kills = 0
print("KILLS: "..kills)
function RoombaKilled()
	Objects.SpawnObject(1, roombaspawn[1], roombaspawn[2], roombaspawn[3])
	Objects.SpawnObject(1, roombaspawn[1], roombaspawn[2], roombaspawn[3])
	kills = kills + 1
	print("KILLS: "..kills)
end
Objects.SpawnObject(0, Objects.FindPlayer()[1], Objects.FindPlayer()[2], Objects.FindPlayer()[3])