all: run

client:
	cd frontend/ && ember build -prod

fast: clean
	cp -r backend/ ./build/
	cp -r frontend/dist/* ./build/wwwroot

build: clean client fast

clean:
	rm -rf ./build

run:
	dnx ./build kestrel

docker: build
	docker build -t turchenkoalex/voteapp .