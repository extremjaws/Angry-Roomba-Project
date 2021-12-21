local roombas = 10
function RoombaKilled()
	roombas = roombas - 1
	print(roombas.." roombas left!")
end
for i=2, roombas do
	Objects.SpawnObject(1, 18, 0, 16)
end
Objects.SpawnObject(0, 26, 0, -24)