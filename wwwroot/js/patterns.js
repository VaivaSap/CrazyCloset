const itemCounts = {};
const itemImages = {};
const itemCategories = {}; 

logs.forEach(log => {
    const itemName = log.ItemName;
    itemCounts[itemName] = (itemCounts[itemName] || 0) + 1;
    if (!itemImages[itemName]) {
        itemImages[itemName] = log.FilePath;
        itemCategories[itemName] = log.Category; 
    }
});

const allLabels = Object.keys(itemCounts);
const allData = Object.values(itemCounts);

const chart = new Chart(document.getElementById('popularityChart'), {
    type: 'bar',
    data: {
        labels: allLabels,
        datasets: [{
            label: 'Times Worn',
            data: allData,
            backgroundColor: 'rgb(255, 165, 0)'
        }]
    },
    options: {
        scales: {
            y: {
                ticks: {
                    stepSize: 1,
                    precision: 0
                }
            }
        },
        onHover: (event, activeElements) => {
            const tooltip = document.getElementById('chartTooltip');
            if (activeElements.length > 0) {
                const index = activeElements[0].index;
                const itemName = chart.data.labels[index];
                const filepath = itemImages[itemName];

                document.getElementById('tooltipImage').src = '/items/' + filepath;
                document.getElementById('tooltipText').textContent = `${itemName}: ${chart.data.datasets[0].data[index]} times`;

                tooltip.style.display = 'block';
                tooltip.style.left = event.native.pageX + 10 + 'px';
                tooltip.style.top = event.native.pageY + 10 + 'px';
            } else {
                tooltip.style.display = 'none';
            }
        }
    }
});

const categories = ['All', ...new Set(Object.values(itemCategories))];
categories.forEach(cat => {
    const btn = document.createElement('button');
    btn.textContent = cat;
    btn.onclick = () => {
        const filtered = cat === 'All'
            ? allLabels
            : allLabels.filter(name => itemCategories[name] === cat);
        chart.data.labels = filtered;
        chart.data.datasets[0].data = filtered.map(name => itemCounts[name]);
        chart.update();
    };
    document.getElementById('categoryFilters').appendChild(btn);
});