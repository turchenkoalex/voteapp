all: run

build: clean
	cp -r backend/ ./build/
	cd frontend/ && ember build -prod
	cp -r frontend/dist/* ./build/wwwroot

clean:
	rm -rf ./build

run:
	dnx ./build kestrel

docker: build
	docker build -t turchenkoalex/voteapp .