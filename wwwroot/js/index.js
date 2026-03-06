function previewImage(event) {
	const image = document.getElementById('imagePreview');
	image.src = URL.createObjectURL(event.target.files[0]);
	image.style.display = 'block';
}

function previewEditImage(event) {
	const image = document.getElementById('editImagePreview');
	image.src = URL.createObjectURL(event.target.files[0]);
	image.style.display = 'block';
}

let startIndex = Math.floor(Math.random() * items.length);

function showImages() {
	if (items.length === 0) {
		document.getElementById('carouselImage1').style.display = 'none';
		return;
	}

	const currentItem = items[startIndex % items.length];
	const currentItem2 = items[(startIndex + 1) % items.length];
	const currentItem3 = items[(startIndex + 2) % items.length];

	document.getElementById('carouselImage1').src = "/items/" + currentItem.FilePath;
	document.getElementById('carouselImage2').src = "/items/" + currentItem2.FilePath;
	document.getElementById('carouselImage3').src = "/items/" + currentItem3.FilePath;


	// gettingthe editing form
	document.getElementById('carouselImage1').onclick = () => openItemEditPopup(currentItem);
	document.getElementById('carouselImage2').onclick = () => openItemEditPopup(currentItem2);
	document.getElementById('carouselImage3').onclick = () => openItemEditPopup(currentItem3);


	document.getElementById('carouselImage1').onmouseenter = (e) => showTooltip(e, currentItem.Name);
	document.getElementById('carouselImage1').onmouseleave = hideTooltip;

	document.getElementById('carouselImage2').onmouseenter = (e) => showTooltip(e, currentItem2.Name);
	document.getElementById('carouselImage2').onmouseleave = hideTooltip;

	document.getElementById('carouselImage3').onmouseenter = (e) => showTooltip(e, currentItem3.Name);
	document.getElementById('carouselImage3').onmouseleave = hideTooltip;

	// check-in also in the carousel
	document.getElementById('checkInBtn1').onclick = (e) => { e.stopPropagation(); document.getElementById('checkInId').value = currentItem.Id; document.getElementById('checkInForm').submit(); };
	document.getElementById('checkInBtn2').onclick = (e) => { e.stopPropagation(); document.getElementById('checkInId').value = currentItem2.Id; document.getElementById('checkInForm').submit(); };
	document.getElementById('checkInBtn3').onclick = (e) => { e.stopPropagation(); document.getElementById('checkInId').value = currentItem3.Id; document.getElementById('checkInForm').submit(); };
}

document.addEventListener('DOMContentLoaded', showImages);

function nextImage() {
	startIndex = (startIndex + 1) % items.length;
	showImages();
}

function previousImage() {
	startIndex = (startIndex - 1 + items.length) % items.length;
	showImages();
}

function searchItems(searchText) {
	const text = searchText.toLowerCase();
	return items.filter(i => {
		const allText = `${i.Name} ${i.Category} ${i.Season} ${i.Description}`.toLowerCase();
		return allText.includes(text);
	});
}

function showSearchResults(filtered) {
	const grid = document.getElementById('searchResultsGrid');
	grid.innerHTML = '';
	filtered.forEach(item => {
		const wrapper = document.createElement('div');
		wrapper.className = 'item-wrapper';
		const img = document.createElement('img');
		img.src = "/items/" + item.FilePath;
		img._data = item;
		img.onclick = () => openItemEditPopup(item);


		wrapper.appendChild(img);
		const checkIn = document.createElement('div');
		checkIn.className = 'checkin-btn';
		checkIn.textContent = '✓';
		checkIn.onclick = (e) => {
			e.stopPropagation();
			document.getElementById('checkInId').value = item.Id;
			document.getElementById('checkInForm').submit();
		};
		wrapper.appendChild(checkIn);

		const heatmapBtn = document.createElement('div');
		heatmapBtn.textContent = '🔥';
		heatmapBtn.onclick = (e) => {
			e.stopPropagation();
			window.location.href = '/ItemHeatmap/' + item.Id;
		};
		wrapper.appendChild(heatmapBtn);

		grid.appendChild(wrapper);
	});
	document.getElementById('searchResults').style.display = 'block';
}


function doSearch() {
	const value = document.getElementById('search').value;
	if (value.trim() === '') {
		document.getElementById('searchResults').style.display = 'none';
		return;
	}
	const filtered = searchItems(value);
	showSearchResults(filtered);
}

document.getElementById('searchButton').addEventListener('click', doSearch);

document.getElementById('search').addEventListener('keydown', function (e) {
	if (e.key === 'Enter') doSearch();
});

document.getElementById('closeSearchResults').addEventListener('click', () => {
	document.getElementById('searchResults').style.display = 'none';
	document.getElementById('search').value = '';
});


function openItemEditPopup(item) {
	document.getElementById('forDisplayAndEdit').style.display = 'flex';

	document.querySelector('#editingItemForm [name="Name"]').value = item.Name;
	document.querySelector('#editingItemForm [name="Description"]').value = item.Description;
	document.querySelector('#editingItemForm [name="Season"]').value = item.Season;
	document.querySelector('#editingItemForm [name="Category"]').value = item.Category;
	document.querySelector('#editingItemForm [name="Size"]').value = item.Size;
	document.querySelector('#editingItemForm [name="ArrivedDate"]').value = item.ArrivedDate;

	document.getElementById("currentItemImage").src = "/items/" + item.FilePath;

	// hidden ones; need for backend that it is known which exactly item to update
	document.getElementById("editItemId").value = item.Id;
	document.getElementById("deleteItemId").value = item.Id;
}

function showTooltip(event, name) {
	const tooltip = document.getElementById('carouselToolTip');
	tooltip.textContent = name;
	tooltip.style.display = 'block';
	tooltip.style.left = event.pageX + 10 + 'px';
	tooltip.style.top = event.pageY + 10 + 'px';
}

function hideTooltip() {
	document.getElementById('carouselToolTip').style.display = 'none';
}
