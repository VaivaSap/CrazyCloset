
function showCategoryPopup(category) {
	const grid = document.getElementById('categoryGrid');
	grid.innerHTML = '';
	const filtered = items.filter(i => i.Category === category);
	filtered.forEach(item => {
		const wrapper = document.createElement('div');
		wrapper.className = 'item-wrapper';
		const img = document.createElement('img');
		img.src = "/items/" + item.FilePath;
		img._data = item;


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
	document.getElementById('categoryPopup').style.display = 'block';
}
